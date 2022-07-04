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
    public class TrenerziesController : Controller
    {
        private readonly TurniejContext _context;

        public TrenerziesController(TurniejContext context)
        {
            _context = context;
        }

        // GET: Trenerzies
        public async Task<IActionResult> Index()
        {
              return _context.Trenerzies != null ? 
                          View(await _context.Trenerzies.ToListAsync()) :
                          Problem("Entity set 'TurniejContext.Trenerzies'  is null.");
        }

        // GET: Trenerzies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trenerzies == null)
            {
                return NotFound();
            }

            var trenerzy = await _context.Trenerzies
                .FirstOrDefaultAsync(m => m.IdTrenera == id);
            if (trenerzy == null)
            {
                return NotFound();
            }

            return View(trenerzy);
        }

        // GET: Trenerzies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trenerzies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTrenera,ImieT,NazwiskoT,IleMedaliT")] Trenerzy trenerzy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trenerzy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trenerzy);
        }

        // GET: Trenerzies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Trenerzies == null)
            {
                return NotFound();
            }

            var trenerzy = await _context.Trenerzies.FindAsync(id);
            if (trenerzy == null)
            {
                return NotFound();
            }
            return View(trenerzy);
        }

        // POST: Trenerzies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTrenera,ImieT,NazwiskoT,IleMedaliT")] Trenerzy trenerzy)
        {
            if (id != trenerzy.IdTrenera)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trenerzy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrenerzyExists(trenerzy.IdTrenera))
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
            return View(trenerzy);
        }

        // GET: Trenerzies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Trenerzies == null)
            {
                return NotFound();
            }

            var trenerzy = await _context.Trenerzies
                .FirstOrDefaultAsync(m => m.IdTrenera == id);
            if (trenerzy == null)
            {
                return NotFound();
            }

            return View(trenerzy);
        }

        // POST: Trenerzies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trenerzies == null)
            {
                return Problem("Entity set 'TurniejContext.Trenerzies'  is null.");
            }
            var trenerzy = await _context.Trenerzies.FindAsync(id);
            if (trenerzy != null)
            {
                _context.Trenerzies.Remove(trenerzy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrenerzyExists(int id)
        {
          return (_context.Trenerzies?.Any(e => e.IdTrenera == id)).GetValueOrDefault();
        }
    }
}
