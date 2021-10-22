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
    public class CultivoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CultivoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cultivo
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cultivo.Include(c => c.IdCategoriaCultivoNavigation).Include(c => c.IdDetalleCultivoNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cultivo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cultivo = await _context.Cultivo
                .Include(c => c.IdCategoriaCultivoNavigation)
                .Include(c => c.IdDetalleCultivoNavigation)
                .FirstOrDefaultAsync(m => m.IdCultivo == id);
            if (cultivo == null)
            {
                return NotFound();
            }

            return View(cultivo);
        }

        // GET: Cultivo/Create
        public IActionResult Create()
        {
            ViewData["IdCategoriaCultivo"] = new SelectList(_context.Categoriacultivo, "IdCategoriaCultivo", "NombreCategoria");
            ViewData["IdDetalleCultivo"] = new SelectList(_context.Set<Detallecultivo>(), "IdDetalleCultivo", "Descripcion");
            return View();
        }

        // POST: Cultivo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCultivo,Nombre,IdCategoriaCultivo,IdDetalleCultivo,Estacion,FechaInicio,FechaTermino,FechaRegistro")] Cultivo cultivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cultivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoriaCultivo"] = new SelectList(_context.Categoriacultivo, "IdCategoriaCultivo", "NombreCategoria", cultivo.IdCategoriaCultivo);
            ViewData["IdDetalleCultivo"] = new SelectList(_context.Set<Detallecultivo>(), "IdDetalleCultivo", "Descripcion", cultivo.IdDetalleCultivo);
            return View(cultivo);
        }

        // GET: Cultivo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cultivo = await _context.Cultivo.FindAsync(id);
            if (cultivo == null)
            {
                return NotFound();
            }
            ViewData["IdCategoriaCultivo"] = new SelectList(_context.Categoriacultivo, "IdCategoriaCultivo", "NombreCategoria", cultivo.IdCategoriaCultivo);
            ViewData["IdDetalleCultivo"] = new SelectList(_context.Set<Detallecultivo>(), "IdDetalleCultivo", "Descripcion", cultivo.IdDetalleCultivo);
            return View(cultivo);
        }

        // POST: Cultivo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCultivo,Nombre,IdCategoriaCultivo,IdDetalleCultivo,Estacion,FechaInicio,FechaTermino,FechaRegistro")] Cultivo cultivo)
        {
            if (id != cultivo.IdCultivo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cultivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CultivoExists(cultivo.IdCultivo))
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
            ViewData["IdCategoriaCultivo"] = new SelectList(_context.Categoriacultivo, "IdCategoriaCultivo", "NombreCategoria", cultivo.IdCategoriaCultivo);
            ViewData["IdDetalleCultivo"] = new SelectList(_context.Set<Detallecultivo>(), "IdDetalleCultivo", "Descripcion", cultivo.IdDetalleCultivo);
            return View(cultivo);
        }

        // GET: Cultivo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cultivo = await _context.Cultivo
                .Include(c => c.IdCategoriaCultivoNavigation)
                .Include(c => c.IdDetalleCultivoNavigation)
                .FirstOrDefaultAsync(m => m.IdCultivo == id);
            if (cultivo == null)
            {
                return NotFound();
            }

            return View(cultivo);
        }

        // POST: Cultivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cultivo = await _context.Cultivo.FindAsync(id);
            _context.Cultivo.Remove(cultivo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CultivoExists(int id)
        {
            return _context.Cultivo.Any(e => e.IdCultivo == id);
        }

    }
}
