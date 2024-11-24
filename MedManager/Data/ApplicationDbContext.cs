using System;
using AP2_MedManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AP2_MedManager.ViewModels;



namespace AP2_MedManager.Data;

public class ApplicationDbContext : IdentityDbContext<Medecin>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
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

        modelBuilder.Entity<Medicament>()
         .HasMany(m => m.Antecedents)
         .WithMany(a => a.Medicaments)
         .UsingEntity(j => j.ToTable("AntecedentMedicament"));

        modelBuilder.Entity<Medicament>()
            .HasMany(m => m.Allergies)
            .WithMany(a => a.Medicaments)
            .UsingEntity(j => j.ToTable("AllergieMedicament"));

        modelBuilder.Entity<Ordonnance>()
            .HasMany(o => o.Medicaments)
            .WithMany(m => m.Ordonnances)
            .UsingEntity(j => j.ToTable("MedicamentOrdonnance"));


        modelBuilder.Entity<Ordonnance>()
            .HasOne(o => o.Patient)
            .WithMany(p => p.Ordonnances)
            .HasForeignKey(o => o.PatientId);

        modelBuilder.Entity<Ordonnance>()
        .HasOne(o => o.Medecin)
        .WithMany(m => m.Ordonnances)
        .HasForeignKey(o => o.MedecinId);

        base.OnModelCreating(modelBuilder);
    }


}
