using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kleide.Models;
using Microsoft.AspNetCore.Authorization;

namespace Kleide.Controllers
{
    //[Authorize]
    public class PrekesController : Controller
    {
        private readonly KleideContext _context;

        public PrekesController(KleideContext context)
        {
            _context = context;
        }

        // GET: Prekes admin
        public async Task<IActionResult> PrekiuKiekis()
        {
            //var kleideContext = _context.Preke.Include(p => p.FkNuomanuomosNumerisNavigation).Include(p => p.FkPirkimasuzsakymoNumerisNavigation).Include(p => p.FkSandelysidSandelysNavigation);
            return View("PrekiuKiekis", _context.Preke.Count());
        }

        // GET: Prekes admin
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var kleideContext = _context.Preke.Include(p => p.FkNuomanuomosNumerisNavigation).Include(p => p.FkPirkimasuzsakymoNumerisNavigation).Include(p => p.FkSandelysidSandelysNavigation);
            return View(await kleideContext.ToListAsync());
        }

        // GET: Prekes
        public async Task<IActionResult> Cards()
        {
            var kleideContext = _context.Preke.Include(p => p.FkNuomanuomosNumerisNavigation).Include(p => p.FkPirkimasuzsakymoNumerisNavigation).Include(p => p.FkSandelysidSandelysNavigation);
            return View(await kleideContext.ToListAsync());
        }

        // GET: Prekes/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preke = await _context.Preke
                .Include(p => p.FkNuomanuomosNumerisNavigation)
                .Include(p => p.FkPirkimasuzsakymoNumerisNavigation)
                .Include(p => p.FkSandelysidSandelysNavigation)
                .SingleOrDefaultAsync(m => m.IdPreke == id);
            if (preke == null)
            {
                return NotFound();
            }

            return View(preke);
        }

        // GET: Prekes/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["Nuotraukos"] = new SelectList(new List<String>() { "/Aksesuaras.jpg", "/DeloreSuknele.jpg", "/JuodaSuknele.jpg" });
            ViewData["FkNuomanuomosNumeris"] = new SelectList(_context.Nuoma, "NuomosNumeris", "NuomosNumeris");
            ViewData["FkPirkimasuzsakymoNumeris"] = new SelectList(_context.Pirkimas, "UzsakymoNumeris", "UzsakymoNumeris");
            ViewData["FkSandelysidSandelys"] = new SelectList(_context.Sandelys, "IdSandelys", "IdSandelys");
            return View();
        }

        // POST: Prekes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create1([Bind("Pavadinimas,Kaina,Dydis,Spalva,Aprasymas,Nuotrauka,PridejimoData,NuomosSkaicius,Bukle,PagaminimoSalis,ArRankuDarbo,RezervavimoTipas,IdPreke,FkPirkimasuzsakymoNumeris,FkNuomanuomosNumeris,FkSandelysidSandelys")] Preke preke)
        {
            var id = 0;
            if (_context.Preke.Count() == 0)
            {
                id = 0;
                preke.IdPreke = 0;
            }
            else
            {
                id = _context.Preke.LastOrDefault().IdPreke + 1;
            }
            if (ModelState.IsValid)
            {
                preke.IdPreke = id;
                _context.Add(preke);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "sukneles", new { id = preke.IdPreke });
            }
            ViewData["FkNuomanuomosNumeris"] = new SelectList(_context.Nuoma, "NuomosNumeris", "NuomosNumeris", preke.FkNuomanuomosNumeris);
            ViewData["FkPirkimasuzsakymoNumeris"] = new SelectList(_context.Pirkimas, "UzsakymoNumeris", "UzsakymoNumeris", preke.FkPirkimasuzsakymoNumeris);
            ViewData["FkSandelysidSandelys"] = new SelectList(_context.Sandelys, "IdSandelys", "IdSandelys", preke.FkSandelysidSandelys);
            return View(preke);
        }

        // POST: Prekes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create2([Bind("Pavadinimas,Kaina,Dydis,Spalva,Aprasymas,Nuotrauka,PridejimoData,NuomosSkaicius,Bukle,PagaminimoSalis,ArRankuDarbo,RezervavimoTipas,IdPreke,FkPirkimasuzsakymoNumeris,FkNuomanuomosNumeris,FkSandelysidSandelys")] Preke preke)
        {
            var id = 0;
            if (_context.Preke.Count() == 0)
            {
                id = 0;
                preke.IdPreke = 0;
            }
            else
            {
                id = _context.Preke.LastOrDefault().IdPreke + 1;
            }
            if (ModelState.IsValid)
            {
                preke.IdPreke = id;
                _context.Add(preke);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "avalynes", new { id = preke.IdPreke });
            }
            ViewData["FkNuomanuomosNumeris"] = new SelectList(_context.Nuoma, "NuomosNumeris", "NuomosNumeris", preke.FkNuomanuomosNumeris);
            ViewData["FkPirkimasuzsakymoNumeris"] = new SelectList(_context.Pirkimas, "UzsakymoNumeris", "UzsakymoNumeris", preke.FkPirkimasuzsakymoNumeris);
            ViewData["FkSandelysidSandelys"] = new SelectList(_context.Sandelys, "IdSandelys", "IdSandelys", preke.FkSandelysidSandelys);
            return View(preke);
        }

        // POST: Prekes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create3([Bind("Pavadinimas,Kaina,Dydis,Spalva,Aprasymas,Nuotrauka,PridejimoData,NuomosSkaicius,Bukle,PagaminimoSalis,ArRankuDarbo,RezervavimoTipas,IdPreke,FkPirkimasuzsakymoNumeris,FkNuomanuomosNumeris,FkSandelysidSandelys")] Preke preke)
        {
            var id = 0;
            if (_context.Preke.Count() == 0)
            {
                id = 0;
                preke.IdPreke = 0;
            }
            else
            {
                id = _context.Preke.LastOrDefault().IdPreke + 1;
            }
            if (ModelState.IsValid)
            {
                preke.IdPreke = id;
                _context.Add(preke);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "aksesuaras", new { id = preke.IdPreke });
            }
            ViewData["FkNuomanuomosNumeris"] = new SelectList(_context.Nuoma, "NuomosNumeris", "NuomosNumeris", preke.FkNuomanuomosNumeris);
            ViewData["FkPirkimasuzsakymoNumeris"] = new SelectList(_context.Pirkimas, "UzsakymoNumeris", "UzsakymoNumeris", preke.FkPirkimasuzsakymoNumeris);
            ViewData["FkSandelysidSandelys"] = new SelectList(_context.Sandelys, "IdSandelys", "IdSandelys", preke.FkSandelysidSandelys);
            return View(preke);
        }

        // GET: Prekes/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preke = await _context.Preke.SingleOrDefaultAsync(m => m.IdPreke == id);
            if (preke == null)
            {
                return NotFound();
            }
            ViewData["FkNuomanuomosNumeris"] = new SelectList(_context.Nuoma, "NuomosNumeris", "NuomosNumeris", preke.FkNuomanuomosNumeris);
            ViewData["FkPirkimasuzsakymoNumeris"] = new SelectList(_context.Pirkimas, "UzsakymoNumeris", "UzsakymoNumeris", preke.FkPirkimasuzsakymoNumeris);
            ViewData["FkSandelysidSandelys"] = new SelectList(_context.Sandelys, "IdSandelys", "IdSandelys", preke.FkSandelysidSandelys);
            return View(preke);
        }

        // POST: Prekes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Pavadinimas,Kaina,Dydis,Spalva,Aprasymas,Nuotrauka,PridejimoData,NuomosSkaicius,Bukle,PagaminimoSalis,ArRankuDarbo,RezervavimoTipas,IdPreke,FkPirkimasuzsakymoNumeris,FkNuomanuomosNumeris,FkSandelysidSandelys")] Preke preke)
        {

            if (id != preke.IdPreke)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(preke);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrekeExists(preke.IdPreke))
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
            ViewData["FkNuomanuomosNumeris"] = new SelectList(_context.Nuoma, "NuomosNumeris", "NuomosNumeris", preke.FkNuomanuomosNumeris);
            ViewData["FkPirkimasuzsakymoNumeris"] = new SelectList(_context.Pirkimas, "UzsakymoNumeris", "UzsakymoNumeris", preke.FkPirkimasuzsakymoNumeris);
            ViewData["FkSandelysidSandelys"] = new SelectList(_context.Sandelys, "IdSandelys", "IdSandelys", preke.FkSandelysidSandelys);
            return View(preke);
        }

        // GET: Prekes/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preke = await _context.Preke
                .Include(p => p.FkNuomanuomosNumerisNavigation)
                .Include(p => p.FkPirkimasuzsakymoNumerisNavigation)
                .Include(p => p.FkSandelysidSandelysNavigation)
                .SingleOrDefaultAsync(m => m.IdPreke == id);
            if (preke == null)
            {
                return NotFound();
            }

            return View(preke);
        }

        // POST: Prekes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var suknele = await _context.Suknele.SingleOrDefaultAsync(m => m.FkPrekeidPreke == id);
            var avalyne = await _context.Avalyne.SingleOrDefaultAsync(m => m.FkPrekeidPreke == id);
            var aksesuaras = await _context.Aksesuaras.SingleOrDefaultAsync(m => m.FkPrekeidPreke == id);
            var preke = await _context.Preke.SingleOrDefaultAsync(m => m.IdPreke == id);
            if (suknele != null)
            {
                _context.Suknele.Remove(suknele);
            }
            else if (avalyne != null)
            {
                _context.Avalyne.Remove(avalyne);
            }
            else if (aksesuaras != null)
            {
                _context.Aksesuaras.Remove(aksesuaras);
            }

            _context.Preke.Remove(preke);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrekeExists(int id)
        {
            return _context.Preke.Any(e => e.IdPreke == id);
        }
    }
}
