using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestion_de_notes.Models
{
    public class Matiere
    {
        [Key]
        public int IdMatiere { get; set; }

        [Required]
        public string NomMatiere { get; set; } = null!;

        public List<Professeur> Professeurs { get; set; } = new List<Professeur>();
        public List<Posseder> Posseders { get; set; } = new List<Posseder>();

        public Matiere()
        {
            
        }
    }
}
