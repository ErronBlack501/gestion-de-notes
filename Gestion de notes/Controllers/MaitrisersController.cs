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
    public class MaitrisersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaitrisersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Maitrisers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Maitriser.Include(m => m.Matiere).Include(m => m.Professeur);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Maitrisers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maitriser = await _context.Maitriser
                .Include(m => m.Matiere)
                .Include(m => m.Professeur)
                .FirstOrDefaultAsync(m => m.ProfesseurId == id);
            if (maitriser == null)
            {
                return NotFound();
            }

            return View(maitriser);
        }

        // GET: Maitrisers/Create
        public IActionResult Create()
        {
            ViewData["MatiereId"] = new SelectList(_context.Matiere, "IdMatiere", "NomMatiere");
            ViewData["ProfesseurId"] = new SelectList(_context.Professeur, "IdProfesseur", "NomPrenom");
            return View();
        }

        // POST: Maitrisers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfesseurId,MatiereId")] Maitriser maitriser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maitriser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MatiereId"] = new SelectList(_context.Matiere, "IdMatiere", "NomMatiere", maitriser.MatiereId);
            ViewData["ProfesseurId"] = new SelectList(_context.Professeur, "IdProfesseur", "NomPrenom", maitriser.ProfesseurId);
            return View(maitriser);
        }

        // GET: Maitrisers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maitriser = await _context.Maitriser.FindAsync(id);
            if (maitriser == null)
            {
                return NotFound();
            }
            ViewData["MatiereId"] = new SelectList(_context.Matiere, "IdMatiere", "NomMatiere", maitriser.MatiereId);
            ViewData["ProfesseurId"] = new SelectList(_context.Professeur, "IdProfesseur", "NomPrenom", maitriser.ProfesseurId);
            return View(maitriser);
        }

        // POST: Maitrisers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfesseurId,MatiereId")] Maitriser maitriser)
        {
            if (id != maitriser.ProfesseurId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maitriser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaitriserExists(maitriser.ProfesseurId))
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
            ViewData["MatiereId"] = new SelectList(_context.Matiere, "IdMatiere", "NomMatiere", maitriser.MatiereId);
            ViewData["ProfesseurId"] = new SelectList(_context.Professeur, "IdProfesseur", "NomPrenom", maitriser.ProfesseurId);
            return View(maitriser);
        }

        // GET: Maitrisers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maitriser = await _context.Maitriser
                .Include(m => m.Matiere)
                .Include(m => m.Professeur)
                .FirstOrDefaultAsync(m => m.ProfesseurId == id);
            if (maitriser == null)
            {
                return NotFound();
            }

            return View(maitriser);
        }

        // POST: Maitrisers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maitriser = await _context.Maitriser.FindAsync(id);
            if (maitriser != null)
            {
                _context.Maitriser.Remove(maitriser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaitriserExists(int id)
        {
            return _context.Maitriser.Any(e => e.ProfesseurId == id);
        }
    }
}
