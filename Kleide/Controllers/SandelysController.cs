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
    public class SandelysController : Controller
    {
        private readonly KleideContext _context;

        public SandelysController(KleideContext context)
        {
            _context = context;
        }

        // GET: Sandelys
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sandelys.ToListAsync());
        }

        // GET: Sandelys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sandelys = await _context.Sandelys
                .SingleOrDefaultAsync(m => m.IdSandelys == id);
            if (sandelys == null)
            {
                return NotFound();
            }

            return View(sandelys);
        }

        // GET: Sandelys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sandelys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Kiekis,PrekesBukle,Miestas,PastoKodas,GatvėsPavadinimas,KontaktinisAsmuo,Salis,SandelioDydis,DarbuotojuKiekis,DarboMasinosKiekis,PrekesTipas,IdSandelys")] Sandelys sandelys)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sandelys);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sandelys);
        }

        // GET: Sandelys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sandelys = await _context.Sandelys.SingleOrDefaultAsync(m => m.IdSandelys == id);
            if (sandelys == null)
            {
                return NotFound();
            }
            return View(sandelys);
        }

        // POST: Sandelys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Kiekis,PrekesBukle,Miestas,PastoKodas,GatvėsPavadinimas,KontaktinisAsmuo,Salis,SandelioDydis,DarbuotojuKiekis,DarboMasinosKiekis,PrekesTipas,IdSandelys")] Sandelys sandelys)
        {
            if (id != sandelys.IdSandelys)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sandelys);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SandelysExists(sandelys.IdSandelys))
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
            return View(sandelys);
        }

        // GET: Sandelys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sandelys = await _context.Sandelys
                .SingleOrDefaultAsync(m => m.IdSandelys == id);
            if (sandelys == null)
            {
                return NotFound();
            }

            return View(sandelys);
        }

        // POST: Sandelys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sandelys = await _context.Sandelys.SingleOrDefaultAsync(m => m.IdSandelys == id);
            _context.Sandelys.Remove(sandelys);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SandelysExists(int id)
        {
            return _context.Sandelys.Any(e => e.IdSandelys == id);
        }
    }
}
