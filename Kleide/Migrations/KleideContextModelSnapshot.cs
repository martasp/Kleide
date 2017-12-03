﻿// <auto-generated />
using Kleide.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Kleide.Migrations
{
    [DbContext(typeof(KleideContext))]
    partial class KleideContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kleide.Models.Aksesuaras", b =>
                {
                    b.Property<int>("IdAksesuaras")
                        .HasColumnName("id_Aksesuaras");

                    b.Property<bool?>("ArElektroninis")
                        .HasColumnName("ar_elektroninis");

                    b.Property<bool?>("ArSuGrandinele")
                        .HasColumnName("ar_su_grandinele");

                    b.Property<int>("FkAksesuaruKategorijaidAksesuaruKategorija")
                        .HasColumnName("fk_Aksesuaru_kategorijaid_Aksesuaru_kategorija");

                    b.Property<int>("FkPrekeidPreke")
                        .HasColumnName("fk_Prekeid_Preke");

                    b.Property<string>("Lytis")
                        .HasColumnName("lytis")
                        .HasColumnType("char(7)");

                    b.Property<string>("MetaloTipas")
                        .HasColumnName("metalo_tipas")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("IdAksesuaras");

                    b.HasIndex("FkAksesuaruKategorijaidAksesuaruKategorija");

                    b.HasIndex("FkPrekeidPreke")
                        .IsUnique()
                        .HasName("UQ__Aksesuar__EFDEFA2005051911");

                    b.ToTable("Aksesuaras");
                });

            modelBuilder.Entity("Kleide.Models.AksesuaruKategorija", b =>
                {
                    b.Property<int>("IdAksesuaruKategorija")
                        .HasColumnName("id_Aksesuaru_kategorija");

                    b.Property<string>("Pavadinimas")
                        .HasColumnName("pavadinimas")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("IdAksesuaruKategorija");

                    b.ToTable("Aksesuaru_kategorija");
                });

            modelBuilder.Entity("Kleide.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Kleide.Models.Asmuo", b =>
                {
                    b.Property<int>("AsmensKodas")
                        .HasColumnName("asmens_kodas");

                    b.Property<string>("Adresas")
                        .HasColumnName("adresas")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("AsmesnsId");

                    b.Property<string>("Miestas")
                        .HasColumnName("miestas")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("PastoKodas")
                        .HasColumnName("pasto_kodas")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Pavarde")
                        .HasColumnName("pavarde")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Salis")
                        .HasColumnName("salis")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Telefonas")
                        .HasColumnName("telefonas")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Vardas")
                        .HasColumnName("vardas")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("AsmensKodas");

                    b.ToTable("Asmuo");
                });

            modelBuilder.Entity("Kleide.Models.Avalyne", b =>
                {
                    b.Property<int>("IdAvalyne")
                        .HasColumnName("id_Avalyne");

                    b.Property<int>("FkPrekeidPreke")
                        .HasColumnName("fk_Prekeid_Preke");

                    b.Property<string>("Lytis")
                        .HasColumnName("lytis")
                        .HasColumnType("char(7)");

                    b.Property<string>("MedziagosTipas")
                        .HasColumnName("medziagos_tipas")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Pobudis")
                        .HasColumnName("pobudis")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<bool?>("SuKulniuku")
                        .HasColumnName("su_kulniuku");

                    b.Property<bool?>("Uzsegimas")
                        .HasColumnName("uzsegimas");

                    b.HasKey("IdAvalyne");

                    b.HasIndex("FkPrekeidPreke")
                        .IsUnique()
                        .HasName("UQ__Avalyne__EFDEFA206FBB2F18");

                    b.ToTable("Avalyne");
                });

            modelBuilder.Entity("Kleide.Models.Draudimas", b =>
                {
                    b.Property<int>("IdDraudimas")
                        .HasColumnName("id_Draudimas");

                    b.Property<string>("DraudimoNumeris")
                        .HasColumnName("draudimo_numeris")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<double?>("DraudimoSuma")
                        .HasColumnName("draudimo_suma");

                    b.Property<int>("FkPrekeidPreke")
                        .HasColumnName("fk_Prekeid_Preke");

                    b.Property<DateTime?>("PabaigosData")
                        .HasColumnName("pabaigos_data")
                        .HasColumnType("date");

                    b.Property<string>("Pobudis")
                        .HasColumnName("pobudis")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<DateTime?>("PradziosData")
                        .HasColumnName("pradzios_data")
                        .HasColumnType("date");

                    b.Property<string>("Tiekejas")
                        .HasColumnName("tiekejas")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("IdDraudimas");

                    b.HasIndex("FkPrekeidPreke")
                        .IsUnique()
                        .HasName("UQ__Draudima__EFDEFA209C9C0485");

                    b.ToTable("Draudimas");
                });

            modelBuilder.Entity("Kleide.Models.Mokejimas", b =>
                {
                    b.Property<int>("MokejimoId")
                        .HasColumnName("mokejimo_id");

                    b.Property<string>("AtsiskaitymoBūdas")
                        .HasColumnName("atsiskaitymo_būdas")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("AtsiėmimoVieta")
                        .HasColumnName("atsiėmimo_vieta");

                    b.Property<DateTime?>("Data")
                        .HasColumnName("data")
                        .HasColumnType("date");

                    b.Property<string>("DraudimoTipas")
                        .HasColumnName("draudimo_tipas")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("MokejimoBusena")
                        .HasColumnName("mokejimo_busena")
                        .HasColumnType("char(10)");

                    b.Property<double?>("NuolaidosSuma")
                        .HasColumnName("nuolaidos_suma");

                    b.Property<double?>("SumoketaSuma")
                        .HasColumnName("sumoketa_suma");

                    b.HasKey("MokejimoId");

                    b.ToTable("Mokejimas");
                });

            modelBuilder.Entity("Kleide.Models.Nuoma", b =>
                {
                    b.Property<int>("NuomosNumeris")
                        .HasColumnName("nuomos_numeris");

                    b.Property<int>("FkAsmuoasmensKodas")
                        .HasColumnName("fk_Asmuoasmens_kodas");

                    b.Property<int>("FkAsmuoasmensKodas1")
                        .HasColumnName("fk_Asmuoasmens_kodas1");

                    b.Property<int>("FkMokejimasmokejimoId")
                        .HasColumnName("fk_Mokejimasmokejimo_id");

                    b.Property<DateTime?>("GrazinimoData")
                        .HasColumnName("grazinimo_data")
                        .HasColumnType("date");

                    b.Property<double?>("Kaina")
                        .HasColumnName("kaina");

                    b.Property<double?>("Kuponas")
                        .HasColumnName("kuponas");

                    b.Property<double?>("Pvm")
                        .HasColumnName("pvm");

                    b.Property<DateTime?>("RezervavimoData")
                        .HasColumnName("rezervavimo_data")
                        .HasColumnType("date");

                    b.HasKey("NuomosNumeris");

                    b.HasIndex("FkAsmuoasmensKodas");

                    b.HasIndex("FkAsmuoasmensKodas1");

                    b.HasIndex("FkMokejimasmokejimoId");

                    b.ToTable("Nuoma");
                });

            modelBuilder.Entity("Kleide.Models.Pirkimas", b =>
                {
                    b.Property<int>("UzsakymoNumeris")
                        .HasColumnName("uzsakymo_numeris");

                    b.Property<bool?>("ArApdrausta")
                        .HasColumnName("ar_apdrausta");

                    b.Property<DateTime?>("Data")
                        .HasColumnName("data")
                        .HasColumnType("date");

                    b.Property<int?>("FkAsmuoasmensKodas")
                        .HasColumnName("fk_Asmuoasmens_kodas");

                    b.Property<int?>("FkAsmuoasmensKodas1")
                        .HasColumnName("fk_Asmuoasmens_kodas1");

                    b.Property<int?>("FkMokejimasmokejimoId")
                        .HasColumnName("fk_Mokejimasmokejimo_id");

                    b.Property<double?>("Kaina")
                        .HasColumnName("kaina");

                    b.Property<double?>("Kuponas")
                        .HasColumnName("kuponas");

                    b.Property<double?>("Pvm")
                        .HasColumnName("pvm");

                    b.HasKey("UzsakymoNumeris");

                    b.HasIndex("FkAsmuoasmensKodas");

                    b.HasIndex("FkAsmuoasmensKodas1");

                    b.HasIndex("FkMokejimasmokejimoId");

                    b.ToTable("Pirkimas");
                });

            modelBuilder.Entity("Kleide.Models.Preke", b =>
                {
                    b.Property<int>("IdPreke")
                        .HasColumnName("id_Preke");

                    b.Property<string>("Aprasymas")
                        .HasColumnName("aprasymas")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<bool>("ArRankuDarbo")
                        .HasColumnName("ar_ranku_darbo");

                    b.Property<string>("Bukle")
                        .HasColumnName("bukle")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Dydis")
                        .HasColumnName("dydis")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int?>("FkNuomanuomosNumeris")
                        .HasColumnName("fk_Nuomanuomos_numeris");

                    b.Property<int?>("FkPirkimasuzsakymoNumeris")
                        .HasColumnName("fk_Pirkimasuzsakymo_numeris");

                    b.Property<int?>("FkSandelysidSandelys")
                        .HasColumnName("fk_Sandelysid_Sandelys");

                    b.Property<int>("Kaina");

                    b.Property<int?>("NuomosSkaicius")
                        .HasColumnName("nuomos_skaicius");

                    b.Property<string>("Nuotrauka")
                        .HasColumnName("nuotrauka")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("PagaminimoSalis")
                        .HasColumnName("pagaminimo_salis")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Pavadinimas")
                        .HasColumnName("pavadinimas")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<DateTime?>("PridejimoData")
                        .HasColumnName("pridejimo_data")
                        .HasColumnType("date");

                    b.Property<string>("RezervavimoTipas")
                        .HasColumnName("rezervavimo_tipas")
                        .HasColumnType("char(17)");

                    b.Property<string>("Spalva")
                        .HasColumnName("spalva")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("IdPreke");

                    b.HasIndex("FkNuomanuomosNumeris")
                        .IsUnique()
                        .HasName("UQ__Preke__BF9E9BB67701A75D")
                        .HasFilter("[fk_Nuomanuomos_numeris] IS NOT NULL");

                    b.HasIndex("FkPirkimasuzsakymoNumeris")
                        .IsUnique()
                        .HasName("UQ__Preke__7E0206E7D43AA57F")
                        .HasFilter("[fk_Pirkimasuzsakymo_numeris] IS NOT NULL");

                    b.HasIndex("FkSandelysidSandelys");

                    b.ToTable("Preke");
                });

            modelBuilder.Entity("Kleide.Models.Role", b =>
                {
                    b.Property<int>("IdRole")
                        .HasColumnName("id_Role");

                    b.Property<int>("FkVartotojasidVartotojas")
                        .HasColumnName("fk_Vartotojasid_Vartotojas");

                    b.Property<int?>("Lygis")
                        .HasColumnName("lygis");

                    b.Property<string>("Pavadinimas")
                        .HasColumnName("pavadinimas")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("IdRole");

                    b.HasIndex("FkVartotojasidVartotojas");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Kleide.Models.Sandelys", b =>
                {
                    b.Property<int>("IdSandelys")
                        .HasColumnName("id_Sandelys");

                    b.Property<int?>("DarboMasinosKiekis")
                        .HasColumnName("darbo_masinos_kiekis");

                    b.Property<int?>("DarbuotojuKiekis")
                        .HasColumnName("darbuotoju_kiekis");

                    b.Property<string>("GatvėsPavadinimas")
                        .HasColumnName("gatvės_pavadinimas")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int?>("Kiekis")
                        .HasColumnName("kiekis");

                    b.Property<string>("KontaktinisAsmuo")
                        .HasColumnName("kontaktinis_asmuo")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Miestas")
                        .HasColumnName("miestas")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("PastoKodas")
                        .HasColumnName("pasto_kodas")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("PrekesBukle")
                        .HasColumnName("prekes_bukle")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("PrekesTipas")
                        .HasColumnName("prekes_tipas")
                        .HasColumnType("char(10)");

                    b.Property<string>("Salis")
                        .HasColumnName("salis")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int?>("SandelioDydis")
                        .HasColumnName("sandelio_dydis");

                    b.HasKey("IdSandelys");

                    b.ToTable("Sandelys");
                });

            modelBuilder.Entity("Kleide.Models.Suknele", b =>
                {
                    b.Property<int>("SuknelesNumeris")
                        .HasColumnName("sukneles_numeris");

                    b.Property<string>("Audinys")
                        .HasColumnName("audinys")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int>("FkPrekeidPreke")
                        .HasColumnName("fk_Prekeid_Preke");

                    b.Property<double?>("Ilgis")
                        .HasColumnName("ilgis");

                    b.Property<string>("ModelioTipas")
                        .HasColumnName("modelio_tipas")
                        .HasColumnType("char(9)");

                    b.HasKey("SuknelesNumeris");

                    b.HasIndex("FkPrekeidPreke")
                        .IsUnique()
                        .HasName("UQ__Suknele__EFDEFA20D956F343");

                    b.ToTable("Suknele");
                });

            modelBuilder.Entity("Kleide.Models.Vartotojas", b =>
                {
                    b.Property<int>("IdVartotojas")
                        .HasColumnName("id_Vartotojas");

                    b.Property<int>("FkAsmuoasmensKodas")
                        .HasColumnName("fk_Asmuoasmens_kodas");

                    b.Property<string>("IpAdresas")
                        .HasColumnName("ip_adresas")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("PrisijungimoVardas")
                        .HasColumnName("prisijungimo_vardas")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Slaptazodis")
                        .HasColumnName("slaptazodis")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("IdVartotojas");

                    b.HasIndex("FkAsmuoasmensKodas")
                        .IsUnique()
                        .HasName("UQ__Vartotoj__BFDBFAF0588FD67A");

                    b.ToTable("Vartotojas");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Kleide.Models.Aksesuaras", b =>
                {
                    b.HasOne("Kleide.Models.AksesuaruKategorija", "FkAksesuaruKategorijaidAksesuaruKategorijaNavigation")
                        .WithMany("Aksesuaras")
                        .HasForeignKey("FkAksesuaruKategorijaidAksesuaruKategorija")
                        .HasConstraintName("turi_1");

                    b.HasOne("Kleide.Models.Preke", "FkPrekeidPrekeNavigation")
                        .WithOne("Aksesuaras")
                        .HasForeignKey("Kleide.Models.Aksesuaras", "FkPrekeidPreke")
                        .HasConstraintName("yra_2");
                });

            modelBuilder.Entity("Kleide.Models.Avalyne", b =>
                {
                    b.HasOne("Kleide.Models.Preke", "FkPrekeidPrekeNavigation")
                        .WithOne("Avalyne")
                        .HasForeignKey("Kleide.Models.Avalyne", "FkPrekeidPreke")
                        .HasConstraintName("yra_1");
                });

            modelBuilder.Entity("Kleide.Models.Draudimas", b =>
                {
                    b.HasOne("Kleide.Models.Preke", "FkPrekeidPrekeNavigation")
                        .WithOne("Draudimas")
                        .HasForeignKey("Kleide.Models.Draudimas", "FkPrekeidPreke")
                        .HasConstraintName("itraukatas");
                });

            modelBuilder.Entity("Kleide.Models.Nuoma", b =>
                {
                    b.HasOne("Kleide.Models.Asmuo", "FkAsmuoasmensKodasNavigation")
                        .WithMany("NuomaFkAsmuoasmensKodasNavigation")
                        .HasForeignKey("FkAsmuoasmensKodas")
                        .HasConstraintName("patvirtina_2");

                    b.HasOne("Kleide.Models.Asmuo", "FkAsmuoasmensKodas1Navigation")
                        .WithMany("NuomaFkAsmuoasmensKodas1Navigation")
                        .HasForeignKey("FkAsmuoasmensKodas1")
                        .HasConstraintName("atlieka");

                    b.HasOne("Kleide.Models.Mokejimas", "FkMokejimasmokejimo")
                        .WithMany("Nuoma")
                        .HasForeignKey("FkMokejimasmokejimoId")
                        .HasConstraintName("uz");
                });

            modelBuilder.Entity("Kleide.Models.Pirkimas", b =>
                {
                    b.HasOne("Kleide.Models.Asmuo", "FkAsmuoasmensKodasNavigation")
                        .WithMany("PirkimasFkAsmuoasmensKodasNavigation")
                        .HasForeignKey("FkAsmuoasmensKodas")
                        .HasConstraintName("patvirtina_1");

                    b.HasOne("Kleide.Models.Asmuo", "FkAsmuoasmensKodas1Navigation")
                        .WithMany("PirkimasFkAsmuoasmensKodas1Navigation")
                        .HasForeignKey("FkAsmuoasmensKodas1")
                        .HasConstraintName("atlieka_1");

                    b.HasOne("Kleide.Models.Mokejimas", "FkMokejimasmokejimo")
                        .WithMany("Pirkimas")
                        .HasForeignKey("FkMokejimasmokejimoId")
                        .HasConstraintName("uz_1");
                });

            modelBuilder.Entity("Kleide.Models.Preke", b =>
                {
                    b.HasOne("Kleide.Models.Nuoma", "FkNuomanuomosNumerisNavigation")
                        .WithOne("Preke")
                        .HasForeignKey("Kleide.Models.Preke", "FkNuomanuomosNumeris")
                        .HasConstraintName("nuomoja");

                    b.HasOne("Kleide.Models.Pirkimas", "FkPirkimasuzsakymoNumerisNavigation")
                        .WithOne("Preke")
                        .HasForeignKey("Kleide.Models.Preke", "FkPirkimasuzsakymoNumeris")
                        .HasConstraintName("perka");

                    b.HasOne("Kleide.Models.Sandelys", "FkSandelysidSandelysNavigation")
                        .WithMany("Preke")
                        .HasForeignKey("FkSandelysidSandelys")
                        .HasConstraintName("turi");
                });

            modelBuilder.Entity("Kleide.Models.Role", b =>
                {
                    b.HasOne("Kleide.Models.Vartotojas", "FkVartotojasidVartotojasNavigation")
                        .WithMany("Role")
                        .HasForeignKey("FkVartotojasidVartotojas")
                        .HasConstraintName("turi_2");
                });

            modelBuilder.Entity("Kleide.Models.Suknele", b =>
                {
                    b.HasOne("Kleide.Models.Preke", "FkPrekeidPrekeNavigation")
                        .WithOne("Suknele")
                        .HasForeignKey("Kleide.Models.Suknele", "FkPrekeidPreke")
                        .HasConstraintName("yra_3");
                });

            modelBuilder.Entity("Kleide.Models.Vartotojas", b =>
                {
                    b.HasOne("Kleide.Models.Asmuo", "FkAsmuoasmensKodasNavigation")
                        .WithOne("Vartotojas")
                        .HasForeignKey("Kleide.Models.Vartotojas", "FkAsmuoasmensKodas")
                        .HasConstraintName("yra");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Kleide.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Kleide.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kleide.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Kleide.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
