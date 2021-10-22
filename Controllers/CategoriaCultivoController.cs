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
    public class CategoriaCultivoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriaCultivoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CategoriaCultivo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categoriacultivo.ToListAsync());
        }

        // GET: CategoriaCultivo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriacultivo = await _context.Categoriacultivo
                .FirstOrDefaultAsync(m => m.IdCategoriaCultivo == id);
            if (categoriacultivo == null)
            {
                return NotFound();
            }

            return View(categoriacultivo);
        }

        // GET: CategoriaCultivo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaCultivo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCategoriaCultivo,NombreCategoria,FechaRegistro")] Categoriacultivo categoriacultivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriacultivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriacultivo);
        }

        // GET: CategoriaCultivo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriacultivo = await _context.Categoriacultivo.FindAsync(id);
            if (categoriacultivo == null)
            {
                return NotFound();
            }
            return View(categoriacultivo);
        }

        // POST: CategoriaCultivo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCategoriaCultivo,NombreCategoria,FechaRegistro")] Categoriacultivo categoriacultivo)
        {
            if (id != categoriacultivo.IdCategoriaCultivo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriacultivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriacultivoExists(categoriacultivo.IdCategoriaCultivo))
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
            return View(categoriacultivo);
        }

        // GET: CategoriaCultivo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriacultivo = await _context.Categoriacultivo
                .FirstOrDefaultAsync(m => m.IdCategoriaCultivo == id);
            if (categoriacultivo == null)
            {
                return NotFound();
            }

            return View(categoriacultivo);
        }

        // POST: CategoriaCultivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriacultivo = await _context.Categoriacultivo.FindAsync(id);
            _context.Categoriacultivo.Remove(categoriacultivo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriacultivoExists(int id)
        {
            return _context.Categoriacultivo.Any(e => e.IdCategoriaCultivo == id);
        }
    }
}
