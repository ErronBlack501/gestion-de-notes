using System.ComponentModel.DataAnnotations;

namespace gestion_de_notes.Models
{
    public class Groupe
    {
        [Key]
        public int IdGroupe { get; set; }

        [Required]
        [StringLength(1)]
        public string Design { get; set; } = null!;

        public List<Eleve> Eleves { get; set; } = new List<Eleve>();

        public Groupe()
        {
            
        }
    }
}
