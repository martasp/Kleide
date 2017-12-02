using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Kleide.Data;
using Kleide.Models;
using Kleide.Services;

namespace Kleide
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //  services.AddDbContext<ApplicationDbContext>(options =>
            //  options.UseSqlServer(Configuration.GetConnectionString("Kleide")));


            //perkelti conection stringa jei leidziama i productiona !!!!
            //var connection = @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=Kleide;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            var connection = "Data Source=SQL6002.site4now.net;Initial Catalog=DB_A2F346_kleide;User Id=DB_A2F346_kleide_admin;Password=Kleide3289;";
            services.AddDbContext<KleideContext>(options => options.UseSqlServer(connection));



            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<KleideContext>()
                    .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            CreateRoles(serviceProvider).Wait();

        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            //adding custom roles
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string[] roleNames = { "Admin", "Member" };
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                //creating the roles and seeding them to the database

                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)

                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            await CreateCustomUserWithRole(UserManager, "Admin");
            //await CreateCustomUserWithRole(UserManager, "Manager");
        }

        private async Task CreateCustomUserWithRole(UserManager<ApplicationUser> UserManager, string role)
        {
            //creating a super user who could maintain the web app ex. manager or admin
            var poweruser = new ApplicationUser
            {
                UserName = Configuration.GetSection("UserSettings")[$"{role}Email"],
                Email = Configuration.GetSection("UserSettings")[$"{role}Email"]
            };
            string UserPassword = Configuration.GetSection("UserSettings")[$"{role}Password"];
            var _user = await UserManager.FindByEmailAsync(Configuration.GetSection("UserSettings")[$"{role}Email"]);
            if (_user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(poweruser, UserPassword);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the "Admin" role 
                    await UserManager.AddToRoleAsync(poweruser, role);
                }
            }
        }
    }
}
