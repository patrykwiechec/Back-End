using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ObiektySportowe.Models;

namespace ObiektySportowe.Controllers
{
    public class ObiektsController : Controller
    {
        private readonly ObiektyContext _context;

        public ObiektsController(ObiektyContext context)
        {
            _context = context;
        }

        // GET: Obiekts
        public async Task<IActionResult> Index(string message)
        {
            using (System.Net.Http.HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:4300/Zawodies/Obiekt/7");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    message = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }

            return _context.Obiekts != null ? 
                          View(await _context.Obiekts.Where(c => c.Lokalizacja == message).ToListAsync()) :
                          Problem("Entity set 'ObiektyContext.Obiekts'  is null.");
        }

        // GET: Obiekts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            using(System.Net.Http.HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:4300/Zawodies/Obiekt/7");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string message = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(message);
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }
            if (id == null || _context.Obiekts == null)
            {
                return NotFound();
            }

            var obiekt = await _context.Obiekts
                .FirstOrDefaultAsync(m => m.IdObiekt == id);
            if (obiekt == null)
            {
                return NotFound();
            }

            return View(obiekt);
        }

        // GET: Obiekts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Obiekts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdObiekt,Lokalizacja,Nazwa,IloscMiejsc,CenaBiletu,CenaBiletuVip")] Obiekt obiekt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obiekt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obiekt);
        }

        // GET: Obiekts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Obiekts == null)
            {
                return NotFound();
            }

            var obiekt = await _context.Obiekts.FindAsync(id);
            if (obiekt == null)
            {
                return NotFound();
            }
            return View(obiekt);
        }

        // POST: Obiekts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdObiekt,Lokalizacja,Nazwa,IloscMiejsc,CenaBiletu,CenaBiletuVip")] Obiekt obiekt)
        {
            if (id != obiekt.IdObiekt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obiekt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObiektExists(obiekt.IdObiekt))
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
            return View(obiekt);
        }

        // GET: Obiekts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Obiekts == null)
            {
                return NotFound();
            }

            var obiekt = await _context.Obiekts
                .FirstOrDefaultAsync(m => m.IdObiekt == id);
            if (obiekt == null)
            {
                return NotFound();
            }

            return View(obiekt);
        }

        // POST: Obiekts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Obiekts == null)
            {
                return Problem("Entity set 'ObiektyContext.Obiekts'  is null.");
            }
            var obiekt = await _context.Obiekts.FindAsync(id);
            if (obiekt != null)
            {
                _context.Obiekts.Remove(obiekt);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObiektExists(int id)
        {
          return (_context.Obiekts?.Any(e => e.IdObiekt == id)).GetValueOrDefault();
        }
    }
}
