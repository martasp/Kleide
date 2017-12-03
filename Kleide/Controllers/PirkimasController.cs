using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kleide.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Kleide.Controllers
{
    public class PirkimasController : Controller
    {
        private readonly KleideContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public PirkimasController(KleideContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Pirkimas
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var kleideContext = _context.Pirkimas.Include(p => p.FkAsmuoasmensKodas1Navigation).Include(p => p.FkAsmuoasmensKodasNavigation).Include(p => p.FkMokejimasmokejimo);
            return View(await kleideContext.ToListAsync());
        }

        // GET: Pirkimas/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pirkimas = await _context.Pirkimas
                .Include(p => p.FkAsmuoasmensKodas1Navigation)
                .Include(p => p.FkAsmuoasmensKodasNavigation)
                .Include(p => p.FkMokejimasmokejimo)
                .SingleOrDefaultAsync(m => m.UzsakymoNumeris == id);
            if (pirkimas == null)
            {
                return NotFound();
            }

            return View(pirkimas);
        }

        // GET: Pirkimas/Create
        [Authorize]
        public IActionResult Create(int id)
        {
            ViewData["UzsakymoNumeris"] = id;
            ViewData["FkAsmuoasmensKodas1"] = new SelectList(_context.Asmuo, "AsmensKodas", "AsmensKodas");
            ViewData["FkAsmuoasmensKodas"] = new SelectList(_context.Asmuo, "AsmensKodas", "AsmensKodas");
            ViewData["FkMokejimasmokejimoId"] = new SelectList(_context.Mokejimas, "MokejimoId", "MokejimoId");
            return View();
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("UzsakymoNumeris,Data,Kaina,Pvm,Kuponas,ArApdrausta,FkMokejimasmokejimoId,FkAsmuoasmensKodas,FkAsmuoasmensKodas1")] Pirkimas pirkimas)
        {
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                var userId = user?.Id;
                pirkimas.ArApdrausta = false;
                pirkimas.Data = DateTime.Now;
                pirkimas.Pvm = 21;
                pirkimas.Kaina = _context.Preke.SingleOrDefault(preke => preke.IdPreke == pirkimas.UzsakymoNumeris).Kaina;
                pirkimas.FkAsmuoasmensKodas = _context.Asmuo.SingleOrDefault(asmuo => asmuo.AsmesnsId == userId).AsmensKodas;

                Mokejimas mokejimas = new Mokejimas
                {
                    AtsiskaitymoBūdas = "-",
                    AtsiėmimoVieta = "Kaunas Studentu Gatve 71",
                    Data = DateTime.Now,
                    DraudimoTipas = "-",
                    MokejimoBusena = "neatliktas",
                    MokejimoId = pirkimas.UzsakymoNumeris,
                    NuolaidosSuma = (int)pirkimas.Kuponas == 3289 ? pirkimas.Kaina * 0.2 : 0,
                    SumoketaSuma = 0,
                };

                if (!PirkimasExists(pirkimas.UzsakymoNumeris))
                {
                    _context.Mokejimas.Add(mokejimas);
                    _context.Add(pirkimas);
                    await _context.SaveChangesAsync();
                    return Redirect($"../../mokejimas/Details/{mokejimas.MokejimoId}");
                }
                return Redirect($"../../mokejimas/Details/{mokejimas.MokejimoId}");
            }
            ViewData["FkAsmuoasmensKodas1"] = new SelectList(_context.Asmuo, "AsmensKodas", "AsmensKodas", pirkimas.FkAsmuoasmensKodas1);
            ViewData["FkAsmuoasmensKodas"] = new SelectList(_context.Asmuo, "AsmensKodas", "AsmensKodas", pirkimas.FkAsmuoasmensKodas);
            ViewData["FkMokejimasmokejimoId"] = new SelectList(_context.Mokejimas, "MokejimoId", "MokejimoId", pirkimas.FkMokejimasmokejimoId);
            return View(pirkimas);
        }

        // GET: Pirkimas/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pirkimas = await _context.Pirkimas.SingleOrDefaultAsync(m => m.UzsakymoNumeris == id);
            if (pirkimas == null)
            {
                return NotFound();
            }
            ViewData["FkAsmuoasmensKodas1"] = new SelectList(_context.Asmuo, "AsmensKodas", "AsmensKodas", pirkimas.FkAsmuoasmensKodas1);
            ViewData["FkAsmuoasmensKodas"] = new SelectList(_context.Asmuo, "AsmensKodas", "AsmensKodas", pirkimas.FkAsmuoasmensKodas);
            ViewData["FkMokejimasmokejimoId"] = new SelectList(_context.Mokejimas, "MokejimoId", "MokejimoId", pirkimas.FkMokejimasmokejimoId);
            return View(pirkimas);
        }

        // POST: Pirkimas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("UzsakymoNumeris,Data,Kaina,Pvm,Kuponas,ArApdrausta,FkMokejimasmokejimoId,FkAsmuoasmensKodas,FkAsmuoasmensKodas1")] Pirkimas pirkimas)
        {
            if (id != pirkimas.UzsakymoNumeris)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pirkimas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PirkimasExists(pirkimas.UzsakymoNumeris))
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
            ViewData["FkAsmuoasmensKodas1"] = new SelectList(_context.Asmuo, "AsmensKodas", "AsmensKodas", pirkimas.FkAsmuoasmensKodas1);
            ViewData["FkAsmuoasmensKodas"] = new SelectList(_context.Asmuo, "AsmensKodas", "AsmensKodas", pirkimas.FkAsmuoasmensKodas);
            ViewData["FkMokejimasmokejimoId"] = new SelectList(_context.Mokejimas, "MokejimoId", "MokejimoId", pirkimas.FkMokejimasmokejimoId);
            return View(pirkimas);
        }

        // GET: Pirkimas/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pirkimas = await _context.Pirkimas
                .Include(p => p.FkAsmuoasmensKodas1Navigation)
                .Include(p => p.FkAsmuoasmensKodasNavigation)
                .Include(p => p.FkMokejimasmokejimo)
                .SingleOrDefaultAsync(m => m.UzsakymoNumeris == id);
            if (pirkimas == null)
            {
                return NotFound();
            }

            return View(pirkimas);
        }

        // POST: Pirkimas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pirkimas = await _context.Pirkimas.SingleOrDefaultAsync(m => m.UzsakymoNumeris == id);
            _context.Pirkimas.Remove(pirkimas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PirkimasExists(int id)
        {
            return _context.Pirkimas.Any(e => e.UzsakymoNumeris == id);
        }
    }
}
