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
    public class DetalleCultivoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetalleCultivoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DetalleCultivo
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Detallecultivo.Include(d => d.IdTipoRiegoNavigation).Include(d => d.IdTipoSueloNavigation).Include(d => d.IdTipoTecnicaNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DetalleCultivo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallecultivo = await _context.Detallecultivo
                .Include(d => d.IdTipoRiegoNavigation)
                .Include(d => d.IdTipoSueloNavigation)
                .Include(d => d.IdTipoTecnicaNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleCultivo == id);
            if (detallecultivo == null)
            {
                return NotFound();
            }

            return View(detallecultivo);
        }

        // GET: DetalleCultivo/Create
        public IActionResult Create()
        {
            ViewData["IdTipoRiego"] = new SelectList(_context.Set<Tiporiego>(), "IdTipoRiego", "NombreTipoRiego");
            ViewData["IdTipoSuelo"] = new SelectList(_context.Set<Tiposuelo>(), "IdTipoSuelo", "NombreTipoSuelo");
            ViewData["IdTipoTecnica"] = new SelectList(_context.Set<Tipotecnica>(), "IdTipoTecnica", "NombreTipoTecnica");
            return View();
        }

        // POST: DetalleCultivo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetalleCultivo,Descripcion,IdTipoTecnica,IdTipoSuelo,IdTipoRiego,FechaRegistro")] Detallecultivo detallecultivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detallecultivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoRiego"] = new SelectList(_context.Set<Tiporiego>(), "IdTipoRiego", "NombreTipoRiego", detallecultivo.IdTipoRiego);
            ViewData["IdTipoSuelo"] = new SelectList(_context.Set<Tiposuelo>(), "IdTipoSuelo", "NombreTipoSuelo", detallecultivo.IdTipoSuelo);
            ViewData["IdTipoTecnica"] = new SelectList(_context.Set<Tipotecnica>(), "IdTipoTecnica", "NombreTipoTecnica", detallecultivo.IdTipoTecnica);
            return View(detallecultivo);
        }

        // GET: DetalleCultivo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallecultivo = await _context.Detallecultivo.FindAsync(id);
            if (detallecultivo == null)
            {
                return NotFound();
            }
            ViewData["IdTipoRiego"] = new SelectList(_context.Set<Tiporiego>(), "IdTipoRiego", "NombreTipoRiego", detallecultivo.IdTipoRiego);
            ViewData["IdTipoSuelo"] = new SelectList(_context.Set<Tiposuelo>(), "IdTipoSuelo", "NombreTipoSuelo", detallecultivo.IdTipoSuelo);
            ViewData["IdTipoTecnica"] = new SelectList(_context.Set<Tipotecnica>(), "IdTipoTecnica", "NombreTipoTecnica", detallecultivo.IdTipoTecnica);
            return View(detallecultivo);
        }

        // POST: DetalleCultivo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDetalleCultivo,Descripcion,IdTipoTecnica,IdTipoSuelo,IdTipoRiego,FechaRegistro")] Detallecultivo detallecultivo)
        {
            if (id != detallecultivo.IdDetalleCultivo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallecultivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallecultivoExists(detallecultivo.IdDetalleCultivo))
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
            ViewData["IdTipoRiego"] = new SelectList(_context.Set<Tiporiego>(), "IdTipoRiego", "NombreTipoRiego", detallecultivo.IdTipoRiego);
            ViewData["IdTipoSuelo"] = new SelectList(_context.Set<Tiposuelo>(), "IdTipoSuelo", "NombreTipoSuelo", detallecultivo.IdTipoSuelo);
            ViewData["IdTipoTecnica"] = new SelectList(_context.Set<Tipotecnica>(), "IdTipoTecnica", "NombreTipoTecnica", detallecultivo.IdTipoTecnica);
            return View(detallecultivo);
        }

        // GET: DetalleCultivo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallecultivo = await _context.Detallecultivo
                .Include(d => d.IdTipoRiegoNavigation)
                .Include(d => d.IdTipoSueloNavigation)
                .Include(d => d.IdTipoTecnicaNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleCultivo == id);
            if (detallecultivo == null)
            {
                return NotFound();
            }

            return View(detallecultivo);
        }

        // POST: DetalleCultivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detallecultivo = await _context.Detallecultivo.FindAsync(id);
            _context.Detallecultivo.Remove(detallecultivo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallecultivoExists(int id)
        {
            return _context.Detallecultivo.Any(e => e.IdDetalleCultivo == id);
        }
    }
}
