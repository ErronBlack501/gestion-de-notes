using System.ComponentModel.DataAnnotations;
namespace gestion_de_notes.Models.Enum
{
    public enum NiveauEnum
    {
        TerminaleS,
        TerminaleL,
        TerminaleOS,
        TerminaleD,
        TerminaleA,
        TerminaleA2,
        Première,
        Seconde,
        [Display(Name = "3ème")]
        Troisième,
        [Display(Name = "4ème")]
        Quatrième,
        [Display(Name = "5ème")]
        Cinquième,
        [Display(Name = "6ème")]
        Sixième
    }

    public enum GroupeEnum
    {
        [Display(Name = "1")]
        I,
        [Display(Name = "2")]
        II,
        A,
        B,
        C,
        D
    }
}
