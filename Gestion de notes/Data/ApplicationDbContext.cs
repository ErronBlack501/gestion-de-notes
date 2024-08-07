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

       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Eleve>()
                .HasOne(e => e.Classe)
                .WithMany(c => c.Eleves)
                .HasForeignKey(e => e.ClasseId);
            modelBuilder.Entity<Eleve>()
               .HasOne(e => e.Groupe)
               .WithMany(g => g.Eleves)
               .HasForeignKey(e => e.GroupeId);
        }*/


        public DbSet<gestion_de_notes.Models.Groupe> Groupe { get; set; } = default!;
        public DbSet<gestion_de_notes.Models.Classe> Classe { get; set; } = default!;
        public DbSet<gestion_de_notes.Models.Eleve> Eleve { get; set; } = default!;
        public DbSet<gestion_de_notes.Models.Matiere> Matiere { get; set; } = default!;
       
    }
}
