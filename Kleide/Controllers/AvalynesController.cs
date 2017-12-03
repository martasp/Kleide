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
    public class AvalynesController : Controller
    {
        private readonly KleideContext _context;

        public AvalynesController(KleideContext context)
        {
            _context = context;
        }

        // GET: Avalynes
        public async Task<IActionResult> Index()
        {
            var kleideContext = _context.Avalyne.Include(a => a.FkPrekeidPrekeNavigation);
            return View(await kleideContext.ToListAsync());
        }

        // GET: Avalynes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avalyne = await _context.Avalyne
                .Include(a => a.FkPrekeidPrekeNavigation)
                .SingleOrDefaultAsync(m => m.IdAvalyne == id);
            if (avalyne == null)
            {
                return NotFound();
            }

            return View(avalyne);
        }

        // GET: Avalynes/Create
        public IActionResult Create(int id)
        {
            ViewData["FkPrekeidPreke"] = new SelectList(_context.Preke.Where(p => p.IdPreke == id), "IdPreke", "Pavadinimas");
            return View();
        }

        // POST: Avalynes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedziagosTipas,Uzsegimas,Pobudis,SuKulniuku,Lytis,IdAvalyne,FkPrekeidPreke")] Avalyne avalyne)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avalyne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkPrekeidPreke"] = new SelectList(_context.Preke, "IdPreke", "IdPreke", avalyne.FkPrekeidPreke);
            return View(avalyne);
        }

        // GET: Avalynes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avalyne = await _context.Avalyne.SingleOrDefaultAsync(m => m.IdAvalyne == id);
            if (avalyne == null)
            {
                return NotFound();
            }
            ViewData["FkPrekeidPreke"] = new SelectList(_context.Preke, "IdPreke", "IdPreke", avalyne.FkPrekeidPreke);
            return View(avalyne);
        }

        // POST: Avalynes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedziagosTipas,Uzsegimas,Pobudis,SuKulniuku,Lytis,IdAvalyne,FkPrekeidPreke")] Avalyne avalyne)
        {
            if (id != avalyne.IdAvalyne)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avalyne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvalyneExists(avalyne.IdAvalyne))
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
            ViewData["FkPrekeidPreke"] = new SelectList(_context.Preke, "IdPreke", "IdPreke", avalyne.FkPrekeidPreke);
            return View(avalyne);
        }

        // GET: Avalynes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avalyne = await _context.Avalyne
                .Include(a => a.FkPrekeidPrekeNavigation)
                .SingleOrDefaultAsync(m => m.IdAvalyne == id);
            if (avalyne == null)
            {
                return NotFound();
            }

            return View(avalyne);
        }

        // POST: Avalynes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var avalyne = await _context.Avalyne.SingleOrDefaultAsync(m => m.IdAvalyne == id);
            _context.Avalyne.Remove(avalyne);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvalyneExists(int id)
        {
            return _context.Avalyne.Any(e => e.IdAvalyne == id);
        }
    }
}
