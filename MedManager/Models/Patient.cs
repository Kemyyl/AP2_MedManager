using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AP2_MedManager.Models;

[Table("patients")]
public class Patient
{
    [Key]
    [Column("PatientId")]
    public int PatientId { get; set; }

    [Column("nom_p")]
    public required string Nom_p { get; set; }

    [Column("prenom_p")]
    public required string Prenom_p { get; set; }

    [Column("sexe_p")]
    public required string Sexe_p { get; set; }

    [Column("age_p")]
    public required string Age_p { get; set; }

    [Column("poids_p")]
    public required string Poids_p { get; set; }

    [Column("num_secu")]
    public required string Num_secu { get; set; }

    public List<Antecedent> Antecedents { get; set; } = new();
    public List<Allergie> Allergies { get; set; } = new();
    public List<Ordonnance> Ordonnances { get; set; } = new();
}
