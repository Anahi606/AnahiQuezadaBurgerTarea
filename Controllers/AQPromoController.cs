using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnahiQuezadaBurgerTarea.Data;
using AnahiQuezadaBurgerTarea.Models;

namespace AnahiQuezadaBurgerTarea.Controllers
{
    public class AQPromoController : Controller
    {
        private readonly AnahiQuezadaBurgerTareaContext _context;

        public AQPromoController(AnahiQuezadaBurgerTareaContext context)
        {
            _context = context;
        }

        // GET: AQPromo
        public async Task<IActionResult> Index()
        {
            var anahiQuezadaBurgerTareaContext = _context.AQPromo.Include(a => a.AQBurger);
            return View(await anahiQuezadaBurgerTareaContext.ToListAsync());
        }

        // GET: AQPromo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aQPromo = await _context.AQPromo
                .Include(a => a.AQBurger)
                .FirstOrDefaultAsync(m => m.AQPromoId == id);
            if (aQPromo == null)
            {
                return NotFound();
            }

            return View(aQPromo);
        }

        // GET: AQPromo/Create
        public IActionResult Create()
        {
            ViewData["AQBurgerId"] = new SelectList(_context.AQBurger, "AQBurgerId", "AQName");
            return View();
        }

        // POST: AQPromo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AQPromoId,AQDescripcion,AQFechaPromo,AQBurgerId")] AQPromo aQPromo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aQPromo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AQBurgerId"] = new SelectList(_context.AQBurger, "AQBurgerId", "AQName", aQPromo.AQBurgerId);
            return View(aQPromo);
        }

        // GET: AQPromo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aQPromo = await _context.AQPromo.FindAsync(id);
            if (aQPromo == null)
            {
                return NotFound();
            }
            ViewData["AQBurgerId"] = new SelectList(_context.AQBurger, "AQBurgerId", "AQName", aQPromo.AQBurgerId);
            return View(aQPromo);
        }

        // POST: AQPromo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AQPromoId,AQDescripcion,AQFechaPromo,AQBurgerId")] AQPromo aQPromo)
        {
            if (id != aQPromo.AQPromoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aQPromo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AQPromoExists(aQPromo.AQPromoId))
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
            ViewData["AQBurgerId"] = new SelectList(_context.AQBurger, "AQBurgerId", "AQName", aQPromo.AQBurgerId);
            return View(aQPromo);
        }

        // GET: AQPromo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aQPromo = await _context.AQPromo
                .Include(a => a.AQBurger)
                .FirstOrDefaultAsync(m => m.AQPromoId == id);
            if (aQPromo == null)
            {
                return NotFound();
            }

            return View(aQPromo);
        }

        // POST: AQPromo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aQPromo = await _context.AQPromo.FindAsync(id);
            if (aQPromo != null)
            {
                _context.AQPromo.Remove(aQPromo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AQPromoExists(int id)
        {
            return _context.AQPromo.Any(e => e.AQPromoId == id);
        }
    }
}
