using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using gestion_de_notes.Models;

namespace gestion_de_notes.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<gestion_de_notes.Models.Eleve> Eleve { get; set; } = default!;
        public DbSet<gestion_de_notes.Models.Examen> Examen { get; set; } = default!;
        public DbSet<gestion_de_notes.Models.Professeur> Professeur { get; set; } = default!;
        public DbSet<gestion_de_notes.Models.Note> Note { get; set; } = default!;
        public DbSet<gestion_de_notes.Models.Matiere> Matiere { get; set; } = default!;
    }
}
