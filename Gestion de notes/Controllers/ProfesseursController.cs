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
    public class ProfesseursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfesseursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Professeurs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Professeur.Include(p => p.Matiere);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Professeurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professeur = await _context.Professeur
                .Include(p => p.Matiere)
                .FirstOrDefaultAsync(m => m.IdProfesseur == id);
            if (professeur == null)
            {
                return NotFound();
            }

            return View(professeur);
        }

        // GET: Professeurs/Create
        public IActionResult Create()
        {
            ViewData["MatiereId"] = new SelectList(_context.Matiere, "IdMatiere", "NomMatiere");
            return View();
        }

        // POST: Professeurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProfesseur,Nom,Prenom,NomPrenom,AdresseProf,NumTel,MatiereId")] Professeur professeur)
        {
            if (ModelState.IsValid)
            {
                professeur.NomPrenom = $"{professeur.Nom} {professeur.Prenom}";
                _context.Add(professeur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MatiereId"] = new SelectList(_context.Matiere, "IdMatiere", "NomMatiere", professeur.MatiereId);
            return View(professeur);
        }

        // GET: Professeurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professeur = await _context.Professeur.FindAsync(id);
            if (professeur == null)
            {
                return NotFound();
            }
            ViewData["MatiereId"] = new SelectList(_context.Matiere, "IdMatiere", "NomMatiere", professeur.MatiereId);
            return View(professeur);
        }

        // POST: Professeurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProfesseur,Nom,Prenom,NomPrenom,AdresseProf,NumTel,MatiereId")] Professeur professeur)
        {
            if (id != professeur.IdProfesseur)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professeur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesseurExists(professeur.IdProfesseur))
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
            ViewData["MatiereId"] = new SelectList(_context.Matiere, "IdMatiere", "NomMatiere", professeur.MatiereId);
            return View(professeur);
        }

        // GET: Professeurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professeur = await _context.Professeur
                .Include(p => p.Matiere)
                .FirstOrDefaultAsync(m => m.IdProfesseur == id);
            if (professeur == null)
            {
                return NotFound();
            }

            return View(professeur);
        }

        // POST: Professeurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professeur = await _context.Professeur.FindAsync(id);
            if (professeur != null)
            {
                _context.Professeur.Remove(professeur);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesseurExists(int id)
        {
            return _context.Professeur.Any(e => e.IdProfesseur == id);
        }
    }
}
