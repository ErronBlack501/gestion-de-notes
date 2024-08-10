using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

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

        [Display(Name = "Nom et Prénom")]
        public string NomPrenom { get; set; } = string.Empty; //unique

        [StringLength(4)]
        [Display(Name = "N° Matricule")]
        [Required]
        public string NumMatricule { get; set; } = null!; //unique

        [Required]
        [Display(Name = "Adresse")]
        public string AdresseEleve { get; set; } = null!;

        [Phone]
        [Display(Name = "Contact des Parents")]
        [Required]
        public string ParentNumTel { get; set; } = null!;

        [EmailAddress]
        [Required]
        public string Email { get; set; } = null!; //unique

        [ForeignKey("ClasseId")]
        [Required]
        public int ClasseId { get; set; }
        public Classe? Classe { get; set; } 

        public List<Note> Notes { get; set; } = new List<Note>();

        public Eleve()
        {
       
        }

    }
}
