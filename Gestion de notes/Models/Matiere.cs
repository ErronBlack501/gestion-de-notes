using System.ComponentModel.DataAnnotations;

namespace gestion_de_notes.Models
{
    public class Matiere
    {
        [Key]
        public int IdMatiere { get; set; }

        [Required]
        public string NomMatiere { get; set; } = null!;

        [Required]
        [Range(0, 10)]
        public ushort Coefficient { get; set; }

        public Matiere()
        {
            
        }
    }
}
