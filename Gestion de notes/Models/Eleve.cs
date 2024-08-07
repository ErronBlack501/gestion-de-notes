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

        [ForeignKey("ClasseId")]
        [Required]
        public int ClasseId { get; set; }
        public Classe? Classe { get; set; } = null!;

        [ForeignKey("GroupeId")]
        [Required]
        public int GroupeId { get; set; }
        
        public Groupe? Groupe { get; set; } 

        public List<Note> Notes { get; set; } = new List<Note>();

        public Eleve()
        {
       
        }

    }
}
