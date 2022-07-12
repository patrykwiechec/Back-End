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
    public class ZawodiesController : Controller
    {
        private readonly TurniejContext _context;

        public ZawodiesController(TurniejContext context)
        {
            _context = context;
        }

        // GET: Zawodies
        public async Task<IActionResult> Index()
        {
            return _context.Zawodies != null ?
                        View(await _context.Zawodies.ToListAsync()) :
                        Problem("Entity set 'TurniejContext.Zawodies'  is null.");
        }

        // GET: Zawodies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Zawodies == null)
            {
                return NotFound();
            }

            var zawody = await _context.Zawodies
                .FirstOrDefaultAsync(m => m.IdZawodow == id);
            if (zawody == null)
            {
                return NotFound();
            }

            return View(zawody);
        }

        [HttpGet]
        public async Task<string> Obiekt(int? id)
        {
            var zawody = await _context.Zawodies
                .FirstOrDefaultAsync(m => m.IdZawodow == id);


            return zawody.Lokalizacja; ;

        }
    

        // GET: Zawodies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zawodies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdZawodow,Nazwa,Lokalizacja")] Zawody zawody)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zawody);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zawody);
        }

        // GET: Zawodies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Zawodies == null)
            {
                return NotFound();
            }

            var zawody = await _context.Zawodies.FindAsync(id);
            if (zawody == null)
            {
                return NotFound();
            }
            return View(zawody);
        }

        // POST: Zawodies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdZawodow,Nazwa,Lokalizacja")] Zawody zawody)
        {
            if (id != zawody.IdZawodow)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zawody);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZawodyExists(zawody.IdZawodow))
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
            return View(zawody);
        }

        // GET: Zawodies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Zawodies == null)
            {
                return NotFound();
            }

            var zawody = await _context.Zawodies
                .FirstOrDefaultAsync(m => m.IdZawodow == id);
            if (zawody == null)
            {
                return NotFound();
            }

            return View(zawody);
        }

        // POST: Zawodies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Zawodies == null)
            {
                return Problem("Entity set 'TurniejContext.Zawodies'  is null.");
            }
            var zawody = await _context.Zawodies.FindAsync(id);
            if (zawody != null)
            {
                _context.Zawodies.Remove(zawody);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZawodyExists(int id)
        {
          return (_context.Zawodies?.Any(e => e.IdZawodow == id)).GetValueOrDefault();
        }
    }
}
