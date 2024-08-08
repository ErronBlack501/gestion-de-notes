using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public string NomPrenom { get; set; } = string.Empty; //Unique

        [Required]
        public string AdresseProf { get; set; } = null!;

        [Phone]
        [Required]
        public string NumTel { get; set; } = null!; //Unique

        public Matiere? Matiere { get; set; } 

        public List<Enseigner> Enseigners { get; set; } = new List<Enseigner>();
        public List<Note> Notes { get; set; } = new List<Note>();
        public List<Maitriser> Maitrisers { get; set; } = new List<Maitriser>();

        public Professeur()
        {
      
        }
    }
}
