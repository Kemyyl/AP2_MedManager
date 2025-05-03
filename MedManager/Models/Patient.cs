using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace AP2_MedManager.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Le nom est requis")]
        public required string Nom_p { get; set; }

        [Required(ErrorMessage = "Le prénom est requis")]
        public required string Prenom_p { get; set; }

        [Required(ErrorMessage = "Le sexe est requis")]
        public required string Sexe_p { get; set; }

        [Required(ErrorMessage = "L'âge est requis")]
        [RegularExpression(@"^\d+$", ErrorMessage = "L'âge doit être un nombre entier")]
        public required string Age_p { get; set; }

        [Required(ErrorMessage = "Le poids est requis")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Le poids doit être un nombre valide (ex: 70 ou 70.5)")]
        public required string Poids_p { get; set; }

        [Required(ErrorMessage = "Le Numéro de sécurité est requis")]
        [RegularExpression(@"^\d{7}$", ErrorMessage = "Le numéro de sécurité doit posséder 7 chiffres")]
        public required string Num_secu { get; set; }

        public List<Antecedent> Antecedents { get; set; } = new();
        public List<Allergie> Allergies { get; set; } = new();
        public List<Ordonnance> Ordonnances { get; set; } = new();
    }
}
