using System;
using AP2_MedManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AP2_MedManager.ViewModels;



namespace AP2_MedManager.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUtilisateur>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    

    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Medecin> Medecins => Set<Medecin>();
    public DbSet<Allergie> Allergies => Set<Allergie>();
    public DbSet<Ordonnance> Ordonnances => Set<Ordonnance>();
    public DbSet<Medicament> Medicaments => Set<Medicament>();
    public DbSet<Antecedent> Antecedents => Set<Antecedent>();






    // Ajout de mock data
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>()
          .HasMany(p => p.Allergies)
          .WithMany(a => a.Patients)
          .UsingEntity(j => j.ToTable("AllergiePatient")); ;

        modelBuilder.Entity<Patient>()
            .HasMany(p => p.Antecedents)
            .WithMany(a => a.Patients)
            .UsingEntity(j => j.ToTable("AntecedentPatient")); ;

        modelBuilder.Entity<Allergie>()
            .HasMany(a => a.Medicaments)
            .WithMany(m => m.Allergies);

        modelBuilder.Entity<Antecedent>()
            .HasMany(a => a.Medicaments)
            .WithMany(m => m.Antecedents);

        modelBuilder.Entity<Ordonnance>()
            .HasOne(o => o.Patient)
            .WithOne(p => p.Ordonnance)
            .HasForeignKey<Ordonnance>(o => o.PatientId);
        base .OnModelCreating(modelBuilder);              
    }


}
