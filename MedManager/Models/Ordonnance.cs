using System;


namespace AP2_MedManager.Models;

public class Ordonnance
{
    
    public int OrdonnanceId { get; set; }
    public required string Posologie { get; set; }
    public required DateTime Date_debut { get; set; }
    public required DateTime Date_fin { get; set; }
    public string? Instructions_specifique { get; set; }
    public required string MedecinId { get; set; }
    public Medecin Medecin { get; set; }
    public int PatientId { get; set; }
    public Patient? Patient { get; set; }
    public List<Medicament> Medicaments { get; set; } = new();
}
