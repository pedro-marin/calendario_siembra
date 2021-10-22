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
    public class RecursoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecursoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recurso
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Recurso.Include(r => r.IdCultivoNavigation).Include(r => r.IdTipoRecursoNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Recurso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recurso = await _context.Recurso
                .Include(r => r.IdCultivoNavigation)
                .Include(r => r.IdTipoRecursoNavigation)
                .FirstOrDefaultAsync(m => m.IdRecurso == id);
            if (recurso == null)
            {
                return NotFound();
            }

            return View(recurso);
        }

        // GET: Recurso/Create
        public IActionResult Create()
        {
            ViewData["IdCultivo"] = new SelectList(_context.Cultivo, "IdCultivo", "Estacion");
            ViewData["IdTipoRecurso"] = new SelectList(_context.Set<Tiporecurso>(), "IdTipoRecurso", "NombreTipoRecurso");
            return View();
        }

        // POST: Recurso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRecurso,IdCultivo,Nombre,IdTipoRecurso,UbicacionRecurso,Tamano,Descripcion,FechaRegistro")] Recurso recurso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recurso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCultivo"] = new SelectList(_context.Cultivo, "IdCultivo", "Estacion", recurso.IdCultivo);
            ViewData["IdTipoRecurso"] = new SelectList(_context.Set<Tiporecurso>(), "IdTipoRecurso", "NombreTipoRecurso", recurso.IdTipoRecurso);
            return View(recurso);
        }

        // GET: Recurso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recurso = await _context.Recurso.FindAsync(id);
            if (recurso == null)
            {
                return NotFound();
            }
            ViewData["IdCultivo"] = new SelectList(_context.Cultivo, "IdCultivo", "Estacion", recurso.IdCultivo);
            ViewData["IdTipoRecurso"] = new SelectList(_context.Set<Tiporecurso>(), "IdTipoRecurso", "NombreTipoRecurso", recurso.IdTipoRecurso);
            return View(recurso);
        }

        // POST: Recurso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRecurso,IdCultivo,Nombre,IdTipoRecurso,UbicacionRecurso,Tamano,Descripcion,FechaRegistro")] Recurso recurso)
        {
            if (id != recurso.IdRecurso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recurso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecursoExists(recurso.IdRecurso))
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
            ViewData["IdCultivo"] = new SelectList(_context.Cultivo, "IdCultivo", "Estacion", recurso.IdCultivo);
            ViewData["IdTipoRecurso"] = new SelectList(_context.Set<Tiporecurso>(), "IdTipoRecurso", "NombreTipoRecurso", recurso.IdTipoRecurso);
            return View(recurso);
        }

        // GET: Recurso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recurso = await _context.Recurso
                .Include(r => r.IdCultivoNavigation)
                .Include(r => r.IdTipoRecursoNavigation)
                .FirstOrDefaultAsync(m => m.IdRecurso == id);
            if (recurso == null)
            {
                return NotFound();
            }

            return View(recurso);
        }

        // POST: Recurso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recurso = await _context.Recurso.FindAsync(id);
            _context.Recurso.Remove(recurso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecursoExists(int id)
        {
            return _context.Recurso.Any(e => e.IdRecurso == id);
        }
    }
}
