using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using calendario.Data;
using calendario.Models;

namespace calendario.Controllers
{
    public class TipoRiegoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoRiegoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoRiego
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tiporiego.ToListAsync());
        }

        // GET: TipoRiego/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiporiego = await _context.Tiporiego
                .FirstOrDefaultAsync(m => m.IdTipoRiego == id);
            if (tiporiego == null)
            {
                return NotFound();
            }

            return View(tiporiego);
        }

        // GET: TipoRiego/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoRiego/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoRiego,NombreTipoRiego,FechaRegistro")] Tiporiego tiporiego)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiporiego);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiporiego);
        }

        // GET: TipoRiego/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiporiego = await _context.Tiporiego.FindAsync(id);
            if (tiporiego == null)
            {
                return NotFound();
            }
            return View(tiporiego);
        }

        // POST: TipoRiego/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoRiego,NombreTipoRiego,FechaRegistro")] Tiporiego tiporiego)
        {
            if (id != tiporiego.IdTipoRiego)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiporiego);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiporiegoExists(tiporiego.IdTipoRiego))
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
            return View(tiporiego);
        }

        // GET: TipoRiego/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiporiego = await _context.Tiporiego
                .FirstOrDefaultAsync(m => m.IdTipoRiego == id);
            if (tiporiego == null)
            {
                return NotFound();
            }

            return View(tiporiego);
        }

        // POST: TipoRiego/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiporiego = await _context.Tiporiego.FindAsync(id);
            _context.Tiporiego.Remove(tiporiego);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiporiegoExists(int id)
        {
            return _context.Tiporiego.Any(e => e.IdTipoRiego == id);
        }
    }
}
