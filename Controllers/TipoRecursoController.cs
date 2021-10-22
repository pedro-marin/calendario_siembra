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
    public class TipoRecursoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoRecursoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoRecurso
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tiporecurso.ToListAsync());
        }

        // GET: TipoRecurso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiporecurso = await _context.Tiporecurso
                .FirstOrDefaultAsync(m => m.IdTipoRecurso == id);
            if (tiporecurso == null)
            {
                return NotFound();
            }

            return View(tiporecurso);
        }

        // GET: TipoRecurso/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoRecurso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoRecurso,NombreTipoRecurso,FechaRegistro")] Tiporecurso tiporecurso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiporecurso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiporecurso);
        }

        // GET: TipoRecurso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiporecurso = await _context.Tiporecurso.FindAsync(id);
            if (tiporecurso == null)
            {
                return NotFound();
            }
            return View(tiporecurso);
        }

        // POST: TipoRecurso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoRecurso,NombreTipoRecurso,FechaRegistro")] Tiporecurso tiporecurso)
        {
            if (id != tiporecurso.IdTipoRecurso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiporecurso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiporecursoExists(tiporecurso.IdTipoRecurso))
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
            return View(tiporecurso);
        }

        // GET: TipoRecurso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiporecurso = await _context.Tiporecurso
                .FirstOrDefaultAsync(m => m.IdTipoRecurso == id);
            if (tiporecurso == null)
            {
                return NotFound();
            }

            return View(tiporecurso);
        }

        // POST: TipoRecurso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiporecurso = await _context.Tiporecurso.FindAsync(id);
            _context.Tiporecurso.Remove(tiporecurso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiporecursoExists(int id)
        {
            return _context.Tiporecurso.Any(e => e.IdTipoRecurso == id);
        }
    }
}
