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
    public class NotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Notes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Note.Include(n => n.Eleve).Include(n => n.Examen).Include(n => n.Matiere).Include(n => n.Professeur);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Notes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.Note
                .Include(n => n.Eleve)
                .Include(n => n.Examen)
                .Include(n => n.Matiere)
                .Include(n => n.Professeur)
                .FirstOrDefaultAsync(m => m.ProfesseurId == id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // GET: Notes/Create
        public IActionResult Create()
        {
            ViewData["EleveId"] = new SelectList(_context.Eleve, "IdEleve", "NomPrenom");
            ViewData["ExamenId"] = new SelectList(_context.Examen, "IdExamen", "Session");
            ViewData["MatiereId"] = new SelectList(_context.Matiere, "IdMatiere", "NomMatiere");
            ViewData["ProfesseurId"] = new SelectList(_context.Professeur, "IdProfesseur", "NomPrenom");
            return View();
        }

        // POST: Notes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NoteEleve,EleveId,ProfesseurId,MatiereId,ExamenId")] Note note)
        {
            if (ModelState.IsValid)
            {
                _context.Add(note);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EleveId"] = new SelectList(_context.Eleve, "IdEleve", "NomPrenom", note.EleveId);
            ViewData["ExamenId"] = new SelectList(_context.Examen, "IdExamen", "Session", note.ExamenId);
            ViewData["MatiereId"] = new SelectList(_context.Matiere, "IdMatiere", "NomMatiere", note.MatiereId);
            ViewData["ProfesseurId"] = new SelectList(_context.Professeur, "IdProfesseur", "NomPrenom", note.ProfesseurId);
            return View(note);
        }

        // GET: Notes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.Note.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }
            ViewData["EleveId"] = new SelectList(_context.Eleve, "IdEleve", "NomPrenom", note.EleveId);
            ViewData["ExamenId"] = new SelectList(_context.Examen, "IdExamen", "Session", note.ExamenId);
            ViewData["MatiereId"] = new SelectList(_context.Matiere, "IdMatiere", "NomMatiere", note.MatiereId);
            ViewData["ProfesseurId"] = new SelectList(_context.Professeur, "IdProfesseur", "NomPrenom", note.ProfesseurId);
            return View(note);
        }

        // POST: Notes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NoteEleve,EleveId,ProfesseurId,MatiereId,ExamenId")] Note note)
        {
            if (id != note.ProfesseurId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(note);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoteExists(note.ProfesseurId))
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
            ViewData["EleveId"] = new SelectList(_context.Eleve, "IdEleve", "NomPrenom", note.EleveId);
            ViewData["ExamenId"] = new SelectList(_context.Examen, "IdExamen", "Session", note.ExamenId);
            ViewData["MatiereId"] = new SelectList(_context.Matiere, "IdMatiere", "NomMatiere", note.MatiereId);
            ViewData["ProfesseurId"] = new SelectList(_context.Professeur, "IdProfesseur", "NomPrenom", note.ProfesseurId);
            return View(note);
        }

        // GET: Notes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.Note
                .Include(n => n.Eleve)
                .Include(n => n.Examen)
                .Include(n => n.Matiere)
                .Include(n => n.Professeur)
                .FirstOrDefaultAsync(m => m.ProfesseurId == id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var note = await _context.Note.FindAsync(id);
            if (note != null)
            {
                _context.Note.Remove(note);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoteExists(int id)
        {
            return _context.Note.Any(e => e.ProfesseurId == id);
        }
    }
}
