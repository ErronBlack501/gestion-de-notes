using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestion_de_notes.Models
{
    public class Note
    {  
        [Required]
        [Precision(3)]
        [Range(0, 20.00)]
        [Display(Name = "Note de l'élève")]
        public double NoteEleve { get; set; }

        [Required]
        [ForeignKey("EleveId")]
        public int EleveId { get; set; }
        [Display(Name = "Elève")]
        public Eleve? Eleve { get; set; } 
        
        [Required]
        [ForeignKey("ProfesseurId")]
        public int ProfesseurId { get; set; }
        public Professeur? Professeur { get; set; }

        [Required]
        [ForeignKey("MatiereId")]
        public int MatiereId { get; set; }
        [Display(Name = "Matière")]
        public Matiere? Matiere { get; set; }

        [Required]
        [ForeignKey("ExamenId")]
        public int ExamenId { get; set; }
        public Examen? Examen { get; set; } 

        public Note()
        {
            
        }
    }
}
