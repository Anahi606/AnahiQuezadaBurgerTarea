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
    public class AQBurgersController : Controller
    {
        private readonly AnahiQuezadaBurgerTareaContext _context;

        public AQBurgersController(AnahiQuezadaBurgerTareaContext context)
        {
            _context = context;
        }

        // GET: AQBurgers
        public async Task<IActionResult> Index()
        {
            return View(await _context.AQBurger.ToListAsync());
        }

        // GET: AQBurgers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aQBurger = await _context.AQBurger
                .FirstOrDefaultAsync(m => m.AQBurgerId == id);
            if (aQBurger == null)
            {
                return NotFound();
            }

            return View(aQBurger);
        }

        // GET: AQBurgers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AQBurgers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AQBurgerId,AQName,AQWithCheese,AQPrecio")] AQBurger aQBurger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aQBurger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aQBurger);
        }

        // GET: AQBurgers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aQBurger = await _context.AQBurger.FindAsync(id);
            if (aQBurger == null)
            {
                return NotFound();
            }
            return View(aQBurger);
        }

        // POST: AQBurgers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AQBurgerId,AQName,AQWithCheese,AQPrecio")] AQBurger aQBurger)
        {
            if (id != aQBurger.AQBurgerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aQBurger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AQBurgerExists(aQBurger.AQBurgerId))
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
            return View(aQBurger);
        }

        // GET: AQBurgers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aQBurger = await _context.AQBurger
                .FirstOrDefaultAsync(m => m.AQBurgerId == id);
            if (aQBurger == null)
            {
                return NotFound();
            }

            return View(aQBurger);
        }

        // POST: AQBurgers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aQBurger = await _context.AQBurger.FindAsync(id);
            if (aQBurger != null)
            {
                _context.AQBurger.Remove(aQBurger);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AQBurgerExists(int id)
        {
            return _context.AQBurger.Any(e => e.AQBurgerId == id);
        }
    }
}
