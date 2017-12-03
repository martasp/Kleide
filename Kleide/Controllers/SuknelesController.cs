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
    public class SuknelesController : Controller
    {
        private readonly KleideContext _context;

        public SuknelesController(KleideContext context)
        {
            _context = context;
        }

        // GET: Sukneles
        public async Task<IActionResult> Index()
        {
            var kleideContext = _context.Suknele.Include(s => s.FkPrekeidPrekeNavigation);
            return View(await kleideContext.ToListAsync());
        }

        // GET: Sukneles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suknele = await _context.Suknele
                .Include(s => s.FkPrekeidPrekeNavigation)
                .SingleOrDefaultAsync(m => m.SuknelesNumeris == id);
            if (suknele == null)
            {
                return NotFound();
            }

            return View(suknele);
        }

        // GET: Sukneles/Create
        public IActionResult Create(int id)
        {
            ViewData["FkPrekeidPreke"] = new SelectList(_context.Preke.Where(p => p.IdPreke == id), "IdPreke", "Pavadinimas");
            return View();
        }

        // POST: Sukneles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SuknelesNumeris,Ilgis,Audinys,ModelioTipas,FkPrekeidPreke")] Suknele suknele)
        {
            if (ModelState.IsValid)
            {

                //var suknele = new Suknele { Audinys = prekesuknele.Audinys };
                //var pake = new Preke { Aksesuaras  = prekesuknele };
                _context.Suknele.Add(suknele);
                //_context.Preke.Add(pake);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkPrekeidPreke"] = new SelectList(_context.Preke, "IdPreke", "Pavadinimas", suknele.FkPrekeidPreke);
            return View(suknele);
        }

        // GET: Sukneles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suknele = await _context.Suknele.SingleOrDefaultAsync(m => m.SuknelesNumeris == id);
            if (suknele == null)
            {
                return NotFound();
            }
            ViewData["FkPrekeidPreke"] = new SelectList(_context.Preke, "IdPreke", "Pavadinimas", suknele.FkPrekeidPreke);
            return View(suknele);
        }

        // POST: Sukneles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SuknelesNumeris,Ilgis,Audinys,ModelioTipas,FkPrekeidPreke")] Suknele suknele)
        {
            if (id != suknele.SuknelesNumeris)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suknele);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SukneleExists(suknele.SuknelesNumeris))
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
            ViewData["FkPrekeidPreke"] = new SelectList(_context.Preke, "IdPreke", "Pavadinimas", suknele.FkPrekeidPreke);
            return View(suknele);
        }

        // GET: Sukneles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suknele = await _context.Suknele
                .Include(s => s.FkPrekeidPrekeNavigation)
                .SingleOrDefaultAsync(m => m.SuknelesNumeris == id);
            if (suknele == null)
            {
                return NotFound();
            }

            return View(suknele);
        }

        // POST: Sukneles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var suknele = await _context.Suknele.SingleOrDefaultAsync(m => m.SuknelesNumeris == id);
            _context.Suknele.Remove(suknele);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SukneleExists(int id)
        {
            return _context.Suknele.Any(e => e.SuknelesNumeris == id);
        }
    }
}
