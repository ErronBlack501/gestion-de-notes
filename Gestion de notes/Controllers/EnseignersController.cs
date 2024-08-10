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
    public class EnseignersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnseignersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Enseigners
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Enseigner.Include(e => e.Classe).Include(e => e.Professeur);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Enseigners/Details/5
        public async Task<IActionResult> Details(int? id, int? pid)
        {
            if (id == null && pid == null)
            {
                return NotFound();
            }

            var enseigner = await _context.Enseigner
                .Include(e => e.Classe)
                .Include(e => e.Professeur)
                .FirstOrDefaultAsync(m => m.ClasseId == id && m.ProfesseurId == pid);
            if (enseigner == null)
            {
                return NotFound();
            }

            return View(enseigner);
        }

        // GET: Enseigners/Create
        public IActionResult Create()
        {
            ViewData["ClasseId"] = new SelectList(_context.Classe, "IdClasse", "Niveau");
            ViewData["ProfesseurId"] = new SelectList(_context.Professeur, "IdProfesseur", "NomPrenom");
            return View();
        }

        // POST: Enseigners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClasseId,ProfesseurId")] Enseigner enseigner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enseigner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClasseId"] = new SelectList(_context.Classe, "IdClasse", "Niveau", enseigner.ClasseId);
            ViewData["ProfesseurId"] = new SelectList(_context.Professeur, "IdProfesseur", "NomPrenom", enseigner.ProfesseurId);
            return View(enseigner);
        }

        //GET: Enseigners/Edit/5
        public async Task<IActionResult> Edit(int? id, int? pid)
        {
            if (id == null && pid == null)
            {
                return NotFound();
            }

            var enseigner = await _context.Enseigner.FindAsync(id, pid);
            if (enseigner == null)
            {
                return NotFound();
            }
            ViewData["ClasseId"] = new SelectList(_context.Classe, "IdClasse", "Niveau", enseigner.ClasseId);
            ViewData["ProfesseurId"] = new SelectList(_context.Professeur, "IdProfesseur", "NomPrenom", enseigner.ProfesseurId);
            return View(enseigner);
        }

        // POST: Enseigners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm]int pid, [Bind("ClasseId,ProfesseurId")] Enseigner enseigner)
        {
            if (id != enseigner.ClasseId || pid != enseigner.ProfesseurId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enseigner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnseignerExists(enseigner.ClasseId, enseigner.ProfesseurId))
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
            ViewData["ClasseId"] = new SelectList(_context.Classe, "IdClasse", "Niveau", enseigner.ClasseId);
            ViewData["ProfesseurId"] = new SelectList(_context.Professeur, "IdProfesseur", "NomPrenom", enseigner.ProfesseurId);
            return View(enseigner);
        }

        // GET: Enseigners/Delete/5
        public async Task<IActionResult> Delete(int? id, int? pid)
        {
            if (id == null && pid == null)
            {
                return NotFound();
            }

            var enseigner = await _context.Enseigner
                .Include(e => e.Classe)
                .Include(e => e.Professeur)
                .FirstOrDefaultAsync(m => m.ClasseId == id && m.ProfesseurId == pid);
            if (enseigner == null)
            {
                return NotFound();
            }

            return View(enseigner);
        }

        // POST: Enseigners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, [FromForm]int pid)
        {
            var enseigner = await _context.Enseigner.FindAsync(id, pid);
            if (enseigner != null)
            {
                _context.Enseigner.Remove(enseigner);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnseignerExists(int id, int pid)
        {
            return _context.Enseigner.Any(e => e.ClasseId == id && e.ProfesseurId == pid);
        }
    }
}
