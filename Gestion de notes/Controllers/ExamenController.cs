using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gestion_de_notes.Data;
using gestion_de_notes.Models;

namespace gestion_de_notes.Controllers
{
    public class ExamenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExamenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Examen
        public async Task<IActionResult> Index()
        {
            return View(await _context.Examen.ToListAsync());
        }

        // GET: Examen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examen = await _context.Examen
                .FirstOrDefaultAsync(m => m.IdExamen == id);
            if (examen == null)
            {
                return NotFound();
            }

            return View(examen);
        }

        // GET: Examen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Examen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdExamen,Session,DebutSession,FinSesssion")] Examen examen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(examen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(examen);
        }

        // GET: Examen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examen = await _context.Examen.FindAsync(id);
            if (examen == null)
            {
                return NotFound();
            }
            return View(examen);
        }

        // POST: Examen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdExamen,Session,DebutSession,FinSesssion")] Examen examen)
        {
            if (id != examen.IdExamen)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(examen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamenExists(examen.IdExamen))
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
            return View(examen);
        }

        // GET: Examen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examen = await _context.Examen
                .FirstOrDefaultAsync(m => m.IdExamen == id);
            if (examen == null)
            {
                return NotFound();
            }

            return View(examen);
        }

        // POST: Examen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var examen = await _context.Examen.FindAsync(id);
            if (examen != null)
            {
                _context.Examen.Remove(examen);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamenExists(int id)
        {
            return _context.Examen.Any(e => e.IdExamen == id);
        }
    }
}
