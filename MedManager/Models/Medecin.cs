using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AP2_MedManager.Models;

public class Medecin : IdentityUser
{
    public DateTime Date_naissance_m { get; set; }
 
    public required string Role { get; set; }

    public List<Ordonnance> Ordonnances { get; set; } = new();
}
