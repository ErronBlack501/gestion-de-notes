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
    public class PossedersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PossedersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Posseders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Posseder.Include(p => p.Classe).Include(p => p.Matiere);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Posseders/Details/5
        public async Task<IActionResult> Details(int? id, int? mid)
        {
            if (id == null && mid == null)
            {
                return NotFound();
            }

            var posseder = await _context.Posseder
                .Include(p => p.Classe)
                .Include(p => p.Matiere)
                .FirstOrDefaultAsync(m => m.ClasseId == id && m.MatiereId == mid);
            if (posseder == null)
            {
                return NotFound();
            }

            return View(posseder);
        }

        // GET: Posseders/Create
        public IActionResult Create()
        {
            ViewData["ClasseId"] = new SelectList(_context.Classe, "IdClasse", "Niveau");
            ViewData["MatiereId"] = new SelectList(_context.Matiere, "IdMatiere", "NomMatiere");
            return View();
        }

        // POST: Posseders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Coefficient,ClasseId,MatiereId")] Posseder posseder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(posseder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClasseId"] = new SelectList(_context.Classe, "IdClasse", "Niveau", posseder.ClasseId);
            ViewData["MatiereId"] = new SelectList(_context.Matiere, "IdMatiere", "NomMatiere", posseder.MatiereId);
            return View(posseder);
        }

        // GET: Posseders/Edit/5
        public async Task<IActionResult> Edit(int? id, int? mid)
        {
            if (id == null && mid == null)
            {
                return NotFound();
            }

            var posseder = await _context.Posseder.FindAsync(id, mid);
            if (posseder == null)
            {
                return NotFound();
            }
            ViewData["ClasseId"] = new SelectList(_context.Classe, "IdClasse", "Niveau", posseder.ClasseId);
            ViewData["MatiereId"] = new SelectList(_context.Matiere, "IdMatiere", "NomMatiere", posseder.MatiereId);
            return View(posseder);
        }

        // POST: Posseders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm]int mid, [Bind("Coefficient,ClasseId,MatiereId")] Posseder posseder)
        {
            if (id != posseder.ClasseId || mid != posseder.MatiereId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(posseder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PossederExists(posseder.ClasseId, posseder.MatiereId))
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
            ViewData["ClasseId"] = new SelectList(_context.Classe, "IdClasse", "Niveau", posseder.ClasseId);
            ViewData["MatiereId"] = new SelectList(_context.Matiere, "IdMatiere", "NomMatiere", posseder.MatiereId);
            return View(posseder);
        }

        // GET: Posseders/Delete/5
        public async Task<IActionResult> Delete(int? id, int? mid)
        {
            if (id == null && mid == null)
            {
                return NotFound();
            }

            var posseder = await _context.Posseder
                .Include(p => p.Classe)
                .Include(p => p.Matiere)
                .FirstOrDefaultAsync(m => m.ClasseId == id && m.MatiereId == mid);
            if (posseder == null)
            {
                return NotFound();
            }

            return View(posseder);
        }

        // POST: Posseders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, [FromForm]int mid)
        {
            var posseder = await _context.Posseder.FindAsync(id, mid);
            if (posseder != null)
            {
                _context.Posseder.Remove(posseder);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PossederExists(int id, int mid)
        {
            return _context.Posseder.Any(e => e.ClasseId == id && e.MatiereId == mid);
        }
    }
}
