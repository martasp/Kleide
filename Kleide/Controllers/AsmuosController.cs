using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kleide.Models;
using Microsoft.AspNetCore.Identity;

namespace Kleide.Controllers
{
    public class AsmuosController : Controller
    {
        private readonly KleideContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public AsmuosController(KleideContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Asmuos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Asmuo.ToListAsync());
        }

        // GET: Asmuos/Details/5
        public async Task<IActionResult> MyInfo()
        {
            var user = await GetCurrentUserAsync();
            var userId = user?.Id;
            var asmuo = await _context.Asmuo
                .SingleOrDefaultAsync(m => m.AsmesnsId == userId);
            if (asmuo == null)
            {
                return NotFound();
            }

            return View("Details", asmuo);
        }

        // GET: Asmuos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Asmuos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AsmensKodas,Vardas,Pavarde,Telefonas,Miestas,Salis,Adresas,PastoKodas")] Asmuo asmuo)
        {
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                var userId = user?.Id;
                asmuo.AsmesnsId = userId;
                _context.Add(asmuo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(asmuo);
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        // GET: Asmuos/myInfo
        public async Task<IActionResult> MyInfoEdit()
        {
            var user = await GetCurrentUserAsync();
            var userId = user?.Id;
            var asmuo = await _context.Asmuo.SingleOrDefaultAsync(m => m.AsmesnsId == userId);
            if (asmuo == null)
            {
                return NotFound();
            }
            return View("Edit", asmuo);
        }

        // POST: Asmuos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AsmensKodas,Vardas,Pavarde,Telefonas,Miestas,Salis,Adresas,PastoKodas")] Asmuo asmuo)
        {
            if (id != asmuo.AsmensKodas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asmuo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsmuoExists(asmuo.AsmensKodas))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(asmuo);
        }

        // GET: Asmuos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asmuo = await _context.Asmuo
                .SingleOrDefaultAsync(m => m.AsmensKodas == id);
            if (asmuo == null)
            {
                return NotFound();
            }

            return View(asmuo);
        }

        // POST: Asmuos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asmuo = await _context.Asmuo.SingleOrDefaultAsync(m => m.AsmensKodas == id);
            _context.Asmuo.Remove(asmuo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsmuoExists(int id)
        {
            return _context.Asmuo.Any(e => e.AsmensKodas == id);
        }
    }
}
