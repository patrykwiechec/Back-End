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
    public class UczestnictwoesController : Controller
    {
        private readonly TurniejContext _context;

        public UczestnictwoesController(TurniejContext context)
        {
            _context = context;
        }

        // GET: Uczestnictwoes
        public async Task<IActionResult> Index()
        {
            var turniejContext = _context.Uczestnictwos.Include(u => u.IdZawodnikaNavigation).Include(u => u.IdZawodowNavigation);
            return View(await turniejContext.ToListAsync());
        }

        // GET: Uczestnictwoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Uczestnictwos == null)
            {
                return NotFound();
            }

            var uczestnictwo = await _context.Uczestnictwos
                .Include(u => u.IdZawodnikaNavigation)
                .Include(u => u.IdZawodowNavigation)
                .FirstOrDefaultAsync(m => m.IdUczestnictwa == id);
            if (uczestnictwo == null)
            {
                return NotFound();
            }

            return View(uczestnictwo);
        }

        // GET: Uczestnictwoes/Create
        public IActionResult Create()
        {
            ViewData["IdZawodnika"] = new SelectList(_context.Zawodnicies, "IdZawodnika", "IdZawodnika");
            ViewData["IdZawodow"] = new SelectList(_context.Zawodies, "IdZawodow", "IdZawodow");
            return View();
        }

        // POST: Uczestnictwoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUczestnictwa,IdZawodnika,IdZawodow")] Uczestnictwo uczestnictwo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uczestnictwo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdZawodnika"] = new SelectList(_context.Zawodnicies, "IdZawodnika", "IdZawodnika", uczestnictwo.IdZawodnika);
            ViewData["IdZawodow"] = new SelectList(_context.Zawodies, "IdZawodow", "IdZawodow", uczestnictwo.IdZawodow);
            return View(uczestnictwo);
        }

        // GET: Uczestnictwoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Uczestnictwos == null)
            {
                return NotFound();
            }

            var uczestnictwo = await _context.Uczestnictwos.FindAsync(id);
            if (uczestnictwo == null)
            {
                return NotFound();
            }
            ViewData["IdZawodnika"] = new SelectList(_context.Zawodnicies, "IdZawodnika", "IdZawodnika", uczestnictwo.IdZawodnika);
            ViewData["IdZawodow"] = new SelectList(_context.Zawodies, "IdZawodow", "IdZawodow", uczestnictwo.IdZawodow);
            return View(uczestnictwo);
        }

        // POST: Uczestnictwoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUczestnictwa,IdZawodnika,IdZawodow")] Uczestnictwo uczestnictwo)
        {
            if (id != uczestnictwo.IdUczestnictwa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uczestnictwo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UczestnictwoExists(uczestnictwo.IdUczestnictwa))
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
            ViewData["IdZawodnika"] = new SelectList(_context.Zawodnicies, "IdZawodnika", "IdZawodnika", uczestnictwo.IdZawodnika);
            ViewData["IdZawodow"] = new SelectList(_context.Zawodies, "IdZawodow", "IdZawodow", uczestnictwo.IdZawodow);
            return View(uczestnictwo);
        }

        // GET: Uczestnictwoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Uczestnictwos == null)
            {
                return NotFound();
            }

            var uczestnictwo = await _context.Uczestnictwos
                .Include(u => u.IdZawodnikaNavigation)
                .Include(u => u.IdZawodowNavigation)
                .FirstOrDefaultAsync(m => m.IdUczestnictwa == id);
            if (uczestnictwo == null)
            {
                return NotFound();
            }

            return View(uczestnictwo);
        }

        // POST: Uczestnictwoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Uczestnictwos == null)
            {
                return Problem("Entity set 'TurniejContext.Uczestnictwos'  is null.");
            }
            var uczestnictwo = await _context.Uczestnictwos.FindAsync(id);
            if (uczestnictwo != null)
            {
                _context.Uczestnictwos.Remove(uczestnictwo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UczestnictwoExists(int id)
        {
          return (_context.Uczestnictwos?.Any(e => e.IdUczestnictwa == id)).GetValueOrDefault();
        }
    }
}
