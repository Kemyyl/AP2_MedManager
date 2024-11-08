using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AP2_MedManager.Models;


public class LoginViewModel
{
    [Required(ErrorMessage = "Nom d'utilisateur requis.")]
    public required string UserName { get; set; }

    [Required(ErrorMessage = "Mot de passe requis.")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
}