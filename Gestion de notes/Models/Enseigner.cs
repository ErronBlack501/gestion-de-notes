using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestion_de_notes.Models
{
    public class Enseigner
    {
        [Required]
        [ForeignKey("ClasseId")]
        public int ClasseId { get; set; }
        public Classe? Classe { get; set; } 

        [Required]
        [ForeignKey("ProfesseurId")]
        public int ProfesseurId { get; set; }
        public Professeur? Professeur { get; set; } 

        public Enseigner() 
        {
        }
    }
}
