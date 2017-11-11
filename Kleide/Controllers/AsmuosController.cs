using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kleide.Models;

namespace Kleide.Controllers
{
    public class AsmuosController : Controller
    {
        private readonly KleideContext _context;

        public AsmuosController(KleideContext context)
        {
            _context = context;
        }

        // GET: Asmuos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Asmuo.ToListAsync());
        }

        // GET: Asmuos/Details/5
        public async Task<IActionResult> Details(int? id)
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
                _context.Add(asmuo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(asmuo);
        }

        // GET: Asmuos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asmuo = await _context.Asmuo.SingleOrDefaultAsync(m => m.AsmensKodas == id);
            if (asmuo == null)
            {
                return NotFound();
            }
            return View(asmuo);
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
