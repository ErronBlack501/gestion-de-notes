using System.ComponentModel.DataAnnotations;

namespace gestion_de_notes.Models
{
    public class Note
    {
        [Key]
        public int IdNote { get; set; }

        [Required]
        [Range(0, 20.0)]
        public decimal? NoteEleve { get; set; }

        [Required]
        public int EleveId { get; set; }
        public Eleve Eleve { get; set; } = null!;

        [Required]
        public int ProfesseurId { get; set; }
        public Professeur Professeur { get; set; } = null!;

        [Required]
        public int ExamenId { get; set; }
        public Examen Examen { get; set; } = null!;

        public Note()
        {

        }
    }
}
