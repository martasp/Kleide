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
    public class AksesuarasController : Controller
    {
        private readonly KleideContext _context;

        public AksesuarasController(KleideContext context)
        {
            _context = context;
        }

        // GET: Aksesuaras
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var kleideContext = _context.Aksesuaras.Include(a => a.FkAksesuaruKategorijaidAksesuaruKategorijaNavigation).Include(a => a.FkPrekeidPrekeNavigation);
            return View(await kleideContext.ToListAsync());
        }

        // GET: Aksesuaras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aksesuaras = await _context.Aksesuaras
                .Include(a => a.FkAksesuaruKategorijaidAksesuaruKategorijaNavigation)
                .Include(a => a.FkPrekeidPrekeNavigation)
                .SingleOrDefaultAsync(m => m.IdAksesuaras == id);
            if (aksesuaras == null)
            {
                return NotFound();
            }

            return View(aksesuaras);
        }

        // GET: Aksesuaras/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create(int id)
        {
            ViewData["FkAksesuaruKategorijaidAksesuaruKategorija"] = new SelectList(_context.AksesuaruKategorija, "IdAksesuaruKategorija", "Pavadinimas");
            ViewData["FkPrekeidPreke"] = new SelectList(_context.Preke.Where(p => p.IdPreke == id), "IdPreke", "Pavadinimas");
            return View();
        }

        // POST: Aksesuaras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("MetaloTipas,ArSuGrandinele,ArElektroninis,Lytis,IdAksesuaras,FkAksesuaruKategorijaidAksesuaruKategorija,FkPrekeidPreke")] Aksesuaras aksesuaras)
        {
            var id = aksesuaras.FkPrekeidPreke;
            
            if (ModelState.IsValid)
            {
                aksesuaras.IdAksesuaras = id;
                _context.Add(aksesuaras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkAksesuaruKategorijaidAksesuaruKategorija"] = new SelectList(_context.AksesuaruKategorija, "IdAksesuaruKategorija", "Pavadinimas", aksesuaras.FkAksesuaruKategorijaidAksesuaruKategorija);
            ViewData["FkPrekeidPreke"] = new SelectList(_context.Preke, "IdPreke", "Pavadinimas", aksesuaras.FkPrekeidPreke);
            return View(aksesuaras);
        }

        // GET: Aksesuaras/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aksesuaras = await _context.Aksesuaras.SingleOrDefaultAsync(m => m.IdAksesuaras == id);
            if (aksesuaras == null)
            {
                return NotFound();
            }
            ViewData["FkAksesuaruKategorijaidAksesuaruKategorija"] = new SelectList(_context.AksesuaruKategorija, "IdAksesuaruKategorija", "Pavadinimas", aksesuaras.FkAksesuaruKategorijaidAksesuaruKategorija);
            ViewData["FkPrekeidPreke"] = new SelectList(_context.Preke, "IdPreke", "Pavadinimas", aksesuaras.FkPrekeidPreke);
            return View(aksesuaras);
        }

        // POST: Aksesuaras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("MetaloTipas,ArSuGrandinele,ArElektroninis,Lytis,IdAksesuaras,FkAksesuaruKategorijaidAksesuaruKategorija,FkPrekeidPreke")] Aksesuaras aksesuaras)
        {
            if (id != aksesuaras.IdAksesuaras)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aksesuaras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AksesuarasExists(aksesuaras.IdAksesuaras))
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
            ViewData["FkAksesuaruKategorijaidAksesuaruKategorija"] = new SelectList(_context.AksesuaruKategorija, "IdAksesuaruKategorija", "Pavadinimas", aksesuaras.FkAksesuaruKategorijaidAksesuaruKategorija);
            ViewData["FkPrekeidPreke"] = new SelectList(_context.Preke, "IdPreke", "Pavadinimas", aksesuaras.FkPrekeidPreke);
            return View(aksesuaras);
        }

        // GET: Aksesuaras/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aksesuaras = await _context.Aksesuaras
                .Include(a => a.FkAksesuaruKategorijaidAksesuaruKategorijaNavigation)
                .Include(a => a.FkPrekeidPrekeNavigation)
                .SingleOrDefaultAsync(m => m.IdAksesuaras == id);
            if (aksesuaras == null)
            {
                return NotFound();
            }

            return View(aksesuaras);
        }

        // POST: Aksesuaras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aksesuaras = await _context.Aksesuaras.SingleOrDefaultAsync(m => m.IdAksesuaras == id);
            _context.Aksesuaras.Remove(aksesuaras);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AksesuarasExists(int id)
        {
            return _context.Aksesuaras.Any(e => e.IdAksesuaras == id);
        }
    }
}
