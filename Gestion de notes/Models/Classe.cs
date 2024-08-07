using System.ComponentModel.DataAnnotations;

namespace gestion_de_notes.Models
{
    public class Classe
    {
        [Key]
        public int IdClasse;

        [Required]
        public string Niveau { get; set; } = null!;

        public List<Enseigner> Enseigners { get; set; } = new List<Enseigner>();
        public List<Matiere> Matieres { get; set; } = new List<Matiere>();
        public List<Eleve> Eleves { get; set; } = new List<Eleve>();
        public List<Posseder> Posseders { get; set; } = new List<Posseder>();

        public Classe()
        {
            
        }
    }
}
