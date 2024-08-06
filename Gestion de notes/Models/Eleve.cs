using System.ComponentModel.DataAnnotations;

namespace gestion_de_notes.Models
{
    public class Eleve
    {
        [Key]
        public int IdEleve { get; set; }

        [Required]
        public string Nom { get; set; } = null!;

        [Required]
        public string Prenom { get; set; } = null!;

        public string NomPrenom { get; set; } = "";

        [StringLength(4)]
        [Required]
        public string NumMatricule { get; set; } = null!;

        [Required]
        public string AdresseEleve { get; set; } = null!;

        [Phone]
        [Required]
        public string ParentNumTel { get; set; } = null!;

        [EmailAddress]
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Classe { get; set; } = null!;

        public List<Note> Notes { get; set; } = new List<Note>();


        public Eleve()
        {
       
        }

    }
}
