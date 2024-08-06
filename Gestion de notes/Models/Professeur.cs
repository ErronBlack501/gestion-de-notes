using System.ComponentModel.DataAnnotations;

namespace gestion_de_notes.Models
{
    public class Professeur
    {
        [Key]
        public int IdProfesseur { get; set; }

        [Required]
        public string Nom { get; set; } = null!;

        [Required]
        public string Prenom { get; set; } = null!;

        public string NomPrenom { get; set; } = "";

        [Required]
        public string AdresseProf { get; set; } = null!;

        [Phone]
        [Required]
        public string NumTel { get; set; } = null!;

        public List<Note> Notes { get; set; } = new List<Note>();


        public Professeur()
        {
      
        }
    }
}
