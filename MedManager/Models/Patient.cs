using System;
using System.ComponentModel.DataAnnotations;

namespace AP2_MedManager.Models;

public class Patient
{
    [Key]
    public int PatientId { get; set; }
    public required string Nom_p { get; set; }
    public required string Prenom_p { get; set; }
    public required string Sexe_p { get; set; }

    public required string Age_p { get; set; }

    public required string Poids_p { get; set; }
    public required string Num_secu { get; set; }

    public List<Antecedent> Antecedents { get; set; } = new();
    public List<Allergie> Allergies { get; set; } = new();
    public List<Ordonnance> Ordonnances { get; set; } = new();
}
