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
    public class NuomasController : Controller
    {
        private readonly KleideContext _context;

        public NuomasController(KleideContext context)
        {
            _context = context;
        }

        // GET: Nuomas
        public async Task<IActionResult> Index()
        {
            var kleideContext = _context.Nuoma.Include(n => n.FkAsmuoasmensKodas1Navigation).Include(n => n.FkAsmuoasmensKodasNavigation).Include(n => n.FkMokejimasmokejimo);
            return View(await kleideContext.ToListAsync());
        }

        // GET: Nuomas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nuoma = await _context.Nuoma
                .Include(n => n.FkAsmuoasmensKodas1Navigation)
                .Include(n => n.FkAsmuoasmensKodasNavigation)
                .Include(n => n.FkMokejimasmokejimo)
                .SingleOrDefaultAsync(m => m.NuomosNumeris == id);
            if (nuoma == null)
            {
                return NotFound();
            }

            return View(nuoma);
        }

        // GET: Nuomas/Create
        public IActionResult Create()
        {
            ViewData["FkAsmuoasmensKodas1"] = new SelectList(_context.Asmuo, "AsmensKodas", "AsmensKodas");
            ViewData["FkAsmuoasmensKodas"] = new SelectList(_context.Asmuo, "AsmensKodas", "AsmensKodas");
            ViewData["FkMokejimasmokejimoId"] = new SelectList(_context.Mokejimas, "MokejimoId", "MokejimoId");
            return View();
        }

        // POST: Nuomas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NuomosNumeris,RezervavimoData,GrazinimoData,Kaina,Pvm,Kuponas,FkMokejimasmokejimoId,FkAsmuoasmensKodas,FkAsmuoasmensKodas1")] Nuoma nuoma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nuoma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkAsmuoasmensKodas1"] = new SelectList(_context.Asmuo, "AsmensKodas", "AsmensKodas", nuoma.FkAsmuoasmensKodas1);
            ViewData["FkAsmuoasmensKodas"] = new SelectList(_context.Asmuo, "AsmensKodas", "AsmensKodas", nuoma.FkAsmuoasmensKodas);
            ViewData["FkMokejimasmokejimoId"] = new SelectList(_context.Mokejimas, "MokejimoId", "MokejimoId", nuoma.FkMokejimasmokejimoId);
            return View(nuoma);
        }

        // GET: Nuomas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nuoma = await _context.Nuoma.SingleOrDefaultAsync(m => m.NuomosNumeris == id);
            if (nuoma == null)
            {
                return NotFound();
            }
            ViewData["FkAsmuoasmensKodas1"] = new SelectList(_context.Asmuo, "AsmensKodas", "AsmensKodas", nuoma.FkAsmuoasmensKodas1);
            ViewData["FkAsmuoasmensKodas"] = new SelectList(_context.Asmuo, "AsmensKodas", "AsmensKodas", nuoma.FkAsmuoasmensKodas);
            ViewData["FkMokejimasmokejimoId"] = new SelectList(_context.Mokejimas, "MokejimoId", "MokejimoId", nuoma.FkMokejimasmokejimoId);
            return View(nuoma);
        }

        // POST: Nuomas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NuomosNumeris,RezervavimoData,GrazinimoData,Kaina,Pvm,Kuponas,FkMokejimasmokejimoId,FkAsmuoasmensKodas,FkAsmuoasmensKodas1")] Nuoma nuoma)
        {
            if (id != nuoma.NuomosNumeris)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nuoma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NuomaExists(nuoma.NuomosNumeris))
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
            ViewData["FkAsmuoasmensKodas1"] = new SelectList(_context.Asmuo, "AsmensKodas", "AsmensKodas", nuoma.FkAsmuoasmensKodas1);
            ViewData["FkAsmuoasmensKodas"] = new SelectList(_context.Asmuo, "AsmensKodas", "AsmensKodas", nuoma.FkAsmuoasmensKodas);
            ViewData["FkMokejimasmokejimoId"] = new SelectList(_context.Mokejimas, "MokejimoId", "MokejimoId", nuoma.FkMokejimasmokejimoId);
            return View(nuoma);
        }

        // GET: Nuomas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nuoma = await _context.Nuoma
                .Include(n => n.FkAsmuoasmensKodas1Navigation)
                .Include(n => n.FkAsmuoasmensKodasNavigation)
                .Include(n => n.FkMokejimasmokejimo)
                .SingleOrDefaultAsync(m => m.NuomosNumeris == id);
            if (nuoma == null)
            {
                return NotFound();
            }

            return View(nuoma);
        }

        // POST: Nuomas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nuoma = await _context.Nuoma.SingleOrDefaultAsync(m => m.NuomosNumeris == id);
            _context.Nuoma.Remove(nuoma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NuomaExists(int id)
        {
            return _context.Nuoma.Any(e => e.NuomosNumeris == id);
        }
    }
}
