using System.ComponentModel.DataAnnotations;
using AP2_MedManager.Models;

namespace AP2_MedManager.ViewModels
{
    public class PatientViewModel
    {
        // Requis pour que le Patient lui-même soit bien soumis
        [Required(ErrorMessage = "Le patient est requis")]
        public Patient? Patient { get; set; }

        public List<Antecedent>? Antecedents { get; set; }
        public List<Allergie>? Allergies { get; set; }

        [Required(ErrorMessage = "Veuillez sélectionner au moins un antécédent.")]
        public List<int> SelectedAntecedentIds { get; set; } = new List<int>();

        [Required(ErrorMessage = "Veuillez sélectionner au moins une allergie.")]
        public List<int> SelectedAllergieIds { get; set; } = new List<int>();
    }
}
