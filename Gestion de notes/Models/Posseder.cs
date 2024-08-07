using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestion_de_notes.Models
{
    public class Posseder
    {
        [Key]
        public int PossederId { get; set; }

        [Required]
        [Range(0, 10)]
        public ushort Coefficient { get; set; }
        
        [ForeignKey("ClasseId")]
        [Required]
        public int ClasseId { get; set; }
        public Classe Classe { get; set; } = null!;
        
        [ForeignKey("MatiereId")]
        [Required]
        public int MatiereId { get; set; }
        public Matiere Matiere { get; set; } = null!;
        
        public Posseder()
        {
            
        }
    }
}
