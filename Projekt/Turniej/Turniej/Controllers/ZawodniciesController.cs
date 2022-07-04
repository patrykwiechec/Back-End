using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Turniej.Context;
using Turniej.Models;

namespace Turniej.Controllers
{
    public class ZawodniciesController : Controller
    {
        private readonly TurniejContext _context;

        public ZawodniciesController(TurniejContext context)
        {
            _context = context;
        }

        // GET: Zawodnicies
        public async Task<IActionResult> Index()
        {
            var turniejContext = _context.Zawodnicies.Include(z => z.IdTreneraNavigation);
            return View(await turniejContext.ToListAsync());
        }

        // GET: Zawodnicies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Zawodnicies == null)
            {
                return NotFound();
            }

            var zawodnicy = await _context.Zawodnicies
                .Include(z => z.IdTreneraNavigation)
                .FirstOrDefaultAsync(m => m.IdZawodnika == id);
            if (zawodnicy == null)
            {
                return NotFound();
            }

            return View(zawodnicy);
        }

        // GET: Zawodnicies/Create
        public IActionResult Create()
        {
            ViewData["IdTrenera"] = new SelectList(_context.Trenerzies, "IdTrenera", "IdTrenera");
            return View();
        }

        // POST: Zawodnicies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdZawodnika,Imie,Nazwisko,Kraj,IleMedaliT,IdTrenera")] Zawodnicy zawodnicy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zawodnicy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTrenera"] = new SelectList(_context.Trenerzies, "IdTrenera", "IdTrenera", zawodnicy.IdTrenera);
            return View(zawodnicy);
        }

        // GET: Zawodnicies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Zawodnicies == null)
            {
                return NotFound();
            }

            var zawodnicy = await _context.Zawodnicies.FindAsync(id);
            if (zawodnicy == null)
            {
                return NotFound();
            }
            ViewData["IdTrenera"] = new SelectList(_context.Trenerzies, "IdTrenera", "IdTrenera", zawodnicy.IdTrenera);
            return View(zawodnicy);
        }

        // POST: Zawodnicies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdZawodnika,Imie,Nazwisko,Kraj,IleMedaliT,IdTrenera")] Zawodnicy zawodnicy)
        {
            if (id != zawodnicy.IdZawodnika)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zawodnicy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZawodnicyExists(zawodnicy.IdZawodnika))
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
            ViewData["IdTrenera"] = new SelectList(_context.Trenerzies, "IdTrenera", "IdTrenera", zawodnicy.IdTrenera);
            return View(zawodnicy);
        }

        // GET: Zawodnicies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Zawodnicies == null)
            {
                return NotFound();
            }

            var zawodnicy = await _context.Zawodnicies
                .Include(z => z.IdTreneraNavigation)
                .FirstOrDefaultAsync(m => m.IdZawodnika == id);
            if (zawodnicy == null)
            {
                return NotFound();
            }

            return View(zawodnicy);
        }

        // POST: Zawodnicies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Zawodnicies == null)
            {
                return Problem("Entity set 'TurniejContext.Zawodnicies'  is null.");
            }
            var zawodnicy = await _context.Zawodnicies.FindAsync(id);
            if (zawodnicy != null)
            {
                _context.Zawodnicies.Remove(zawodnicy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZawodnicyExists(int id)
        {
          return (_context.Zawodnicies?.Any(e => e.IdZawodnika == id)).GetValueOrDefault();
        }
    }
}
