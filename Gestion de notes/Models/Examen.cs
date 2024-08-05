using System.ComponentModel.DataAnnotations;

namespace gestion_de_notes.Models
{
    public class Examen
    {
        public int IdExamen { get; set; }

        [Required]
        public string Session { get; set; } = null!;

        [DataType(DataType.Date)]
        [Required]
        public DateTime DebutSession { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime FinSesssion { get; set; }

        public List<Note> Notes { get; set; } = new List<Note>();

        public Examen()
        {
        }
    }
}
