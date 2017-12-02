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
    public class MokejimasController : Controller
    {
        private readonly KleideContext _context;

        public MokejimasController(KleideContext context)
        {
            _context = context;
        }

        // GET: Mokejimas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mokejimas.ToListAsync());
        }

        // GET: Mokejimas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mokejimas = await _context.Mokejimas
                .SingleOrDefaultAsync(m => m.MokejimoId == id);
            if (mokejimas == null)
            {
                return NotFound();
            }

            return View(mokejimas);
        }

        // GET: Mokejimas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mokejimas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MokejimoId,Data,SumoketaSuma,AtsiskaitymoBūdas,DraudimoTipas,NuolaidosSuma,AtsiėmimoVieta,MokejimoBusena")] Mokejimas mokejimas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mokejimas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mokejimas);
        }

        // GET: Mokejimas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mokejimas = await _context.Mokejimas.SingleOrDefaultAsync(m => m.MokejimoId == id);
            if (mokejimas == null)
            {
                return NotFound();
            }
            return View(mokejimas);
        }

        // POST: Mokejimas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MokejimoId,Data,SumoketaSuma,AtsiskaitymoBūdas,DraudimoTipas,NuolaidosSuma,AtsiėmimoVieta,MokejimoBusena")] Mokejimas mokejimas)
        {
            if (id != mokejimas.MokejimoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mokejimas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MokejimasExists(mokejimas.MokejimoId))
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
            return View(mokejimas);
        }

        // GET: Mokejimas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mokejimas = await _context.Mokejimas
                .SingleOrDefaultAsync(m => m.MokejimoId == id);
            if (mokejimas == null)
            {
                return NotFound();
            }

            return View(mokejimas);
        }

        // POST: Mokejimas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mokejimas = await _context.Mokejimas.SingleOrDefaultAsync(m => m.MokejimoId == id);
            _context.Mokejimas.Remove(mokejimas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MokejimasExists(int id)
        {
            return _context.Mokejimas.Any(e => e.MokejimoId == id);
        }
    }
}
