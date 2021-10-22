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
    public class TipoTecnicaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoTecnicaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoTecnica
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipotecnica.ToListAsync());
        }

        // GET: TipoTecnica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipotecnica = await _context.Tipotecnica
                .FirstOrDefaultAsync(m => m.IdTipoTecnica == id);
            if (tipotecnica == null)
            {
                return NotFound();
            }

            return View(tipotecnica);
        }

        // GET: TipoTecnica/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoTecnica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoTecnica,NombreTipoTecnica,FechaRegistro")] Tipotecnica tipotecnica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipotecnica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipotecnica);
        }

        // GET: TipoTecnica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipotecnica = await _context.Tipotecnica.FindAsync(id);
            if (tipotecnica == null)
            {
                return NotFound();
            }
            return View(tipotecnica);
        }

        // POST: TipoTecnica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoTecnica,NombreTipoTecnica,FechaRegistro")] Tipotecnica tipotecnica)
        {
            if (id != tipotecnica.IdTipoTecnica)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipotecnica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipotecnicaExists(tipotecnica.IdTipoTecnica))
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
            return View(tipotecnica);
        }

        // GET: TipoTecnica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipotecnica = await _context.Tipotecnica
                .FirstOrDefaultAsync(m => m.IdTipoTecnica == id);
            if (tipotecnica == null)
            {
                return NotFound();
            }

            return View(tipotecnica);
        }

        // POST: TipoTecnica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipotecnica = await _context.Tipotecnica.FindAsync(id);
            _context.Tipotecnica.Remove(tipotecnica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipotecnicaExists(int id)
        {
            return _context.Tipotecnica.Any(e => e.IdTipoTecnica == id);
        }
    }
}
