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
    public class ElevesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ElevesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Eleves
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Eleve.Include(e => e.Classe).Include(e => e.Groupe);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Eleves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eleve = await _context.Eleve
                .Include(e => e.Classe)
                .Include(e => e.Groupe)
                .FirstOrDefaultAsync(m => m.IdEleve == id);
            if (eleve == null)
            {
                return NotFound();
            }

            return View(eleve);
        }

        // GET: Eleves/Create
        public IActionResult Create()
        {
            ViewData["ClasseId"] = new SelectList(_context.Classe, "IdClasse", "Niveau");
            ViewData["GroupeId"] = new SelectList(_context.Groupe, "IdGroupe", "Design");
            return View();
        }

        // POST: Eleves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEleve,Nom,Prenom,NomPrenom,NumMatricule,AdresseEleve,ParentNumTel,Email,ClasseId,GroupeId")] Eleve eleve)
        {
            eleve.NomPrenom = $"{eleve.Nom} {eleve.Prenom}";
   
            if (ModelState.IsValid)
            {
                _context.Add(eleve);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach(var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            ViewData["ClasseId"] = new SelectList(_context.Classe, "IdClasse", "Niveau", eleve.ClasseId);
            ViewData["GroupeId"] = new SelectList(_context.Groupe, "IdGroupe", "Design", eleve.GroupeId);
            return View(eleve);
        }

        // GET: Eleves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eleve = await _context.Eleve.FindAsync(id);
            if (eleve == null)
            {
                return NotFound();
            }
            ViewData["ClasseId"] = new SelectList(_context.Classe, "IdClasse", "Niveau", eleve.ClasseId);
            ViewData["GroupeId"] = new SelectList(_context.Groupe, "IdGroupe", "Design", eleve.GroupeId);
            return View(eleve);
        }

        // POST: Eleves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEleve,Nom,Prenom,NomPrenom,NumMatricule,AdresseEleve,ParentNumTel,Email,ClasseId,GroupeId")] Eleve eleve)
        {
            if (id != eleve.IdEleve)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    eleve.NomPrenom = $"{eleve.Nom} {eleve.Prenom}";
                    _context.Update(eleve);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EleveExists(eleve.IdEleve))
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
            ViewData["ClasseId"] = new SelectList(_context.Classe, "IdClasse", "Niveau", eleve.ClasseId);
            ViewData["GroupeId"] = new SelectList(_context.Groupe, "IdGroupe", "Design", eleve.GroupeId);
            return View(eleve);
        }

        // GET: Eleves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eleve = await _context.Eleve
                .Include(e => e.Classe)
                .Include(e => e.Groupe)
                .FirstOrDefaultAsync(m => m.IdEleve == id);
            if (eleve == null)
            {
                return NotFound();
            }

            return View(eleve);
        }

        // POST: Eleves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eleve = await _context.Eleve.FindAsync(id);
            if (eleve != null)
            {
                _context.Eleve.Remove(eleve);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EleveExists(int id)
        {
            return _context.Eleve.Any(e => e.IdEleve == id);
        }
    }
}
