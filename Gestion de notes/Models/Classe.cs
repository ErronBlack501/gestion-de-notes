using gestion_de_notes.Models.Enum;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestion_de_notes.Models
{
    public class Classe
    {
        [Key]
        public int IdClasse { get; set; }

        [Required]
        public NiveauEnum Niveau { get; set; } 

        [Required]
        public GroupeEnum Groupe { get; set; }

        [Display(Name = "Niveau-Groupe")]
        public string NiveauGrp { get; set; } = string.Empty; //unique

        public List<Enseigner> Enseigners { get; set; } = new List<Enseigner>();
        public List<Eleve> Eleves { get; set; } = new List<Eleve>();
        public List<Posseder> Posseders { get; set; } = new List<Posseder>();

        public Classe()
        {
            
        }
    }
}
