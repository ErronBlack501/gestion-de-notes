using System.ComponentModel.DataAnnotations;

namespace gestion_de_notes.Models
{
    public class Examen
    {
        [Key]
        public int IdExamen { get; set; }

        [Required]
        public string Session { get; set; } = null!; //Unique

        [DataType(DataType.Date)]
        [Display(Name = "Début session")]
        [Required]
        public DateTime DebutSession { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fin session")]
        [Required]
        public DateTime FinSesssion { get; set; }

        public List<Note> Notes { get; set; } = new List<Note>();

        public Examen()
        {

        }
    }
}
