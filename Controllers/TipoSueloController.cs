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
    public class TipoSueloController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoSueloController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoSuelo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tiposuelo.ToListAsync());
        }

        // GET: TipoSuelo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposuelo = await _context.Tiposuelo
                .FirstOrDefaultAsync(m => m.IdTipoSuelo == id);
            if (tiposuelo == null)
            {
                return NotFound();
            }

            return View(tiposuelo);
        }

        // GET: TipoSuelo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoSuelo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoSuelo,NombreTipoSuelo,FechaRegistro")] Tiposuelo tiposuelo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposuelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposuelo);
        }

        // GET: TipoSuelo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposuelo = await _context.Tiposuelo.FindAsync(id);
            if (tiposuelo == null)
            {
                return NotFound();
            }
            return View(tiposuelo);
        }

        // POST: TipoSuelo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoSuelo,NombreTipoSuelo,FechaRegistro")] Tiposuelo tiposuelo)
        {
            if (id != tiposuelo.IdTipoSuelo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposuelo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposueloExists(tiposuelo.IdTipoSuelo))
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
            return View(tiposuelo);
        }

        // GET: TipoSuelo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposuelo = await _context.Tiposuelo
                .FirstOrDefaultAsync(m => m.IdTipoSuelo == id);
            if (tiposuelo == null)
            {
                return NotFound();
            }

            return View(tiposuelo);
        }

        // POST: TipoSuelo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiposuelo = await _context.Tiposuelo.FindAsync(id);
            _context.Tiposuelo.Remove(tiposuelo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposueloExists(int id)
        {
            return _context.Tiposuelo.Any(e => e.IdTipoSuelo == id);
        }
    }
}
