using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestion_de_notes.Models
{
    public class Note
    {
        [Required]
        [Range(0, 20.0)]
        [Precision(3)]
        public double? NoteEleve { get; set; }

        [Required]
        [ForeignKey("EleveId")]
        public int EleveId { get; set; }
        public Eleve Eleve { get; set; } = null!;

        [Required]
        [ForeignKey("ProfesseurId")]
        public int ProfesseurId { get; set; }
        public Professeur Professeur { get; set; } = null!;

        [Required]
        [ForeignKey("ExamenId")]
        public int ExamenId { get; set; }
        public Examen Examen { get; set; } = null!;

        [Required]
        [ForeignKey("MatiereId")]
        public int MatiereId { get; set; }
        public Matiere Matiere { get; set; } = null!;

        public Note()
        {

        }
    }
}
