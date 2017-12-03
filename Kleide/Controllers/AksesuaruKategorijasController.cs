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
    public class AksesuaruKategorijasController : Controller
    {
        private readonly KleideContext _context;

        public AksesuaruKategorijasController(KleideContext context)
        {
            _context = context;
        }

        // GET: AksesuaruKategorijas
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.AksesuaruKategorija.ToListAsync());
        }

        // GET: AksesuaruKategorijas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aksesuaruKategorija = await _context.AksesuaruKategorija
                .SingleOrDefaultAsync(m => m.IdAksesuaruKategorija == id);
            if (aksesuaruKategorija == null)
            {
                return NotFound();
            }

            return View(aksesuaruKategorija);
        }

        // GET: AksesuaruKategorijas/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: AksesuaruKategorijas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Pavadinimas,IdAksesuaruKategorija")] AksesuaruKategorija aksesuaruKategorija)
        {
            var id = _context.AksesuaruKategorija.LastOrDefault().IdAksesuaruKategorija + 1;
            if (ModelState.IsValid)
            {
                aksesuaruKategorija.IdAksesuaruKategorija = id;
                _context.Add(aksesuaruKategorija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aksesuaruKategorija);
        }

        // GET: AksesuaruKategorijas/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aksesuaruKategorija = await _context.AksesuaruKategorija.SingleOrDefaultAsync(m => m.IdAksesuaruKategorija == id);
            if (aksesuaruKategorija == null)
            {
                return NotFound();
            }
            return View(aksesuaruKategorija);
        }

        // POST: AksesuaruKategorijas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Pavadinimas,IdAksesuaruKategorija")] AksesuaruKategorija aksesuaruKategorija)
        {
            if (id != aksesuaruKategorija.IdAksesuaruKategorija)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aksesuaruKategorija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AksesuaruKategorijaExists(aksesuaruKategorija.IdAksesuaruKategorija))
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
            return View(aksesuaruKategorija);
        }

        // GET: AksesuaruKategorijas/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aksesuaruKategorija = await _context.AksesuaruKategorija
                .SingleOrDefaultAsync(m => m.IdAksesuaruKategorija == id);
            if (aksesuaruKategorija == null)
            {
                return NotFound();
            }

            return View(aksesuaruKategorija);
        }

        // POST: AksesuaruKategorijas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aksesuaruKategorija = await _context.AksesuaruKategorija.SingleOrDefaultAsync(m => m.IdAksesuaruKategorija == id);
            _context.AksesuaruKategorija.Remove(aksesuaruKategorija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AksesuaruKategorijaExists(int id)
        {
            return _context.AksesuaruKategorija.Any(e => e.IdAksesuaruKategorija == id);
        }
    }
}
