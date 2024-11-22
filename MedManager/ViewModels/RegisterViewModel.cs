using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AP2_MedManager.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Le champ Nom d'utilisateur est obligatoire.")]
    public required string UserName { get; set; }

    [Required(ErrorMessage = "Le champ Email est obligatoire.")]
    [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Le champ Nom de famille est obligatoire.")]
    public required string Nom_m { get; set; }

    [Required(ErrorMessage = "Le champ Prénom est obligatoire.")]
    public required string Prenom_m { get; set; }

    [Required(ErrorMessage = "Le champ Mot de passe est obligatoire.")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }

    [Required(ErrorMessage = "Le champ Confirmer le mot de passe est obligatoire.")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public required string ConfirmPassword { get; set; }

}
