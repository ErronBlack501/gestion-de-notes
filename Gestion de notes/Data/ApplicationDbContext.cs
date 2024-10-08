﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Eleve Model:
            modelBuilder.Entity<Eleve>()
                .HasIndex(e => new { e.Email, e.NumMatricule, e.NomPrenom })
                .IsUnique();
            modelBuilder.Entity<Eleve>()
                .HasOne(e => e.Classe)
                .WithMany(c => c.Eleves)
                .HasForeignKey(e => e.ClasseId);
          

            //Professeur Model:
            modelBuilder.Entity<Professeur>()
              .HasIndex(p => new { p.NumTel, p.NomPrenom })
              .IsUnique();
       
            //Examen Model:
            modelBuilder.Entity<Examen>()
                .HasIndex(e => e.Session)
                .IsUnique();

            //Matiere Model:
            modelBuilder.Entity<Matiere>()
                .HasIndex(m => m.NomMatiere)
                .IsUnique();

            //Classe Model:
            modelBuilder.Entity<Classe>()
                .HasIndex(c => c.NiveauGrp)
                .IsUnique();

            //Posseder Model:
            modelBuilder.Entity<Posseder>()
                .HasKey(p => new { p.ClasseId, p.MatiereId });
            modelBuilder.Entity<Posseder>()
                .HasOne(p => p.Matiere)
                .WithMany(m => m.Posseders)
                .HasForeignKey(p => p.MatiereId);
            modelBuilder.Entity<Posseder>()
               .HasOne(p => p.Classe)
               .WithMany(m => m.Posseders)
               .HasForeignKey(p => p.ClasseId);

            //Enseigner Model:
            modelBuilder.Entity<Enseigner>()
                .HasKey(e => new { e.ClasseId, e.ProfesseurId });
            modelBuilder.Entity<Enseigner>()
                .HasOne(e => e.Classe)
                .WithMany(c => c.Enseigners)
                .HasForeignKey(e => e.ClasseId);
            modelBuilder.Entity<Enseigner>()
               .HasOne(e => e.Professeur)
               .WithMany(p => p.Enseigners)
               .HasForeignKey(e => e.ProfesseurId);

            //Note Model:
            modelBuilder.Entity<Note>()
                .HasKey(n => new { n.EleveId, n.ProfesseurId, n.MatiereId, n.ExamenId });
            modelBuilder.Entity<Note>()
                .HasOne(n => n.Professeur)
                .WithMany(p => p.Notes)
                .HasForeignKey(n => n.ProfesseurId);
            modelBuilder.Entity<Note>()
               .HasOne(n => n.Matiere)
               .WithMany(m => m.Notes)
               .HasForeignKey(n => n.MatiereId);
            modelBuilder.Entity<Note>()
               .HasOne(n => n.Eleve)
               .WithMany(e => e.Notes)
               .HasForeignKey(n => n.EleveId);
            modelBuilder.Entity<Note>()
               .HasOne(n => n.Examen)
               .WithMany(ex => ex.Notes)
               .HasForeignKey(n => n.ExamenId);

            //Maitriser Model:
            modelBuilder.Entity<Maitriser>()
                .HasKey(m => new { m.ProfesseurId, m.MatiereId });
            modelBuilder.Entity<Maitriser>()
                .HasOne(m => m.Professeur)
                .WithMany(p => p.Maitrisers)
                .HasForeignKey(m =>  m.ProfesseurId);
            modelBuilder.Entity<Maitriser>()
               .HasOne(m => m.Matiere)
               .WithMany(mat => mat.Maitrisers)
               .HasForeignKey(m => m.MatiereId);

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<gestion_de_notes.Models.Classe> Classe { get; set; } = default!;
        public DbSet<gestion_de_notes.Models.Eleve> Eleve { get; set; } = default!;
        public DbSet<gestion_de_notes.Models.Matiere> Matiere { get; set; } = default!;
        public DbSet<gestion_de_notes.Models.Professeur> Professeur { get; set; } = default!;
        public DbSet<gestion_de_notes.Models.Examen> Examen { get; set; } = default!;
        public DbSet<gestion_de_notes.Models.Posseder> Posseder { get; set; } = default!;
        public DbSet<gestion_de_notes.Models.Enseigner> Enseigner { get; set; } = default!;
        public DbSet<gestion_de_notes.Models.Note> Note { get; set; } = default!;
        public DbSet<gestion_de_notes.Models.Maitriser> Maitriser { get; set; } = default!;     
    }
}
