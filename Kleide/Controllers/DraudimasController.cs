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
    public class DraudimasController : Controller
    {
        private readonly KleideContext _context;

        public DraudimasController(KleideContext context)
        {
            _context = context;
        }

        // GET: Draudimas
        public async Task<IActionResult> Index()
        {
            var kleideContext = _context.Draudimas.Include(d => d.FkPrekeidPrekeNavigation);
            return View(await kleideContext.ToListAsync());
        }

        // GET: Draudimas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var draudimas = await _context.Draudimas
                .Include(d => d.FkPrekeidPrekeNavigation)
                .SingleOrDefaultAsync(m => m.IdDraudimas == id);
            if (draudimas == null)
            {
                return NotFound();
            }

            return View(draudimas);
        }

        // GET: Draudimas/Create
        public IActionResult Create()
        {
            ViewData["FkPrekeidPreke"] = new SelectList(_context.Preke, "IdPreke", "Pavadinimas");
            return View();
        }

        // POST: Draudimas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PradziosData,PabaigosData,DraudimoSuma,Tiekejas,Pobudis,DraudimoNumeris,IdDraudimas,FkPrekeidPreke")] Draudimas draudimas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(draudimas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkPrekeidPreke"] = new SelectList(_context.Preke, "pavadinimas", "pavadinimas", draudimas.FkPrekeidPreke);
            return View(draudimas);
        }

        // GET: Draudimas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var draudimas = await _context.Draudimas.SingleOrDefaultAsync(m => m.IdDraudimas == id);
            if (draudimas == null)
            {
                return NotFound();
            }
            ViewData["FkPrekeidPreke"] = new SelectList(_context.Preke, "IdPreke", "Pavadinimas", draudimas.FkPrekeidPreke);

            return View(draudimas);
        }

        // POST: Draudimas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PradziosData,PabaigosData,DraudimoSuma,Tiekejas,Pobudis,DraudimoNumeris,IdDraudimas,FkPrekeidPreke")] Draudimas draudimas)
        {
            if (id != draudimas.IdDraudimas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(draudimas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DraudimasExists(draudimas.IdDraudimas))
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
            ViewData["FkPrekeidPreke"] = new SelectList(_context.Preke, "IdPreke", "IdPreke", draudimas.FkPrekeidPreke);
            return View(draudimas);
        }

        // GET: Draudimas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var draudimas = await _context.Draudimas
                .Include(d => d.FkPrekeidPrekeNavigation)
                .SingleOrDefaultAsync(m => m.IdDraudimas == id);
            if (draudimas == null)
            {
                return NotFound();
            }

            return View(draudimas);
        }

        // POST: Draudimas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var draudimas = await _context.Draudimas.SingleOrDefaultAsync(m => m.IdDraudimas == id);
            _context.Draudimas.Remove(draudimas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DraudimasExists(int id)
        {
            return _context.Draudimas.Any(e => e.IdDraudimas == id);
        }
    }
}
