﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestion_de_notes.Models
{
    public class Matiere
    {
        [Key]
        public int IdMatiere { get; set; }

        [Required]
        [Display(Name = "Nom de la matière")]
        public string NomMatiere { get; set; } = null!; //unique

        public List<Professeur> Professeurs { get; set; } = new List<Professeur>();
        public List<Posseder> Posseders { get; set; } = new List<Posseder>();
        public List<Note> Notes { get; set; } = new List<Note>();
        public List<Maitriser> Maitrisers { get; set; } = new List<Maitriser>();


        public Matiere()
        {
            
        }
    }
}
