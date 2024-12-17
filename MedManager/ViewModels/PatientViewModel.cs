using System;
using System.ComponentModel.DataAnnotations;
using AP2_MedManager.Models;

namespace AP2_MedManager.ViewModels;


public class PatientViewModel
{
    [Required]
    public Patient? Patient { get; set; }
    public List<Antecedent>? Antecedents { get; set; }
    public List<Allergie>? Allergies { get; set; }
    public List<int> SelectedAntecedentIds { get; set; } = new List<int>();
    public List<int> SelectedAllergieIds { get; set; } = new List<int>();
}