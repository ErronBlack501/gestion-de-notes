using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestion_de_notes.Models
{
    public class Maitriser
    {
        [Required]
        [ForeignKey("ProfesseurId")]
        public int ProfesseurId { get; set; }
        public Professeur? Professeur { get; set; } 

        [Required]
        [ForeignKey("MatiereId")]
        public int MatiereId { get; set; }
        public Matiere? Matiere { get; set; }
        public Maitriser() 
        { 
        }
    }
}
