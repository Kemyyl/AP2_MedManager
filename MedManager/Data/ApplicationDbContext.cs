using System;
using ASPBookProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPBookProject.Data;

public class ApplicationDbContext : DbContext
{
    // Nous allons creer un dbset pour chaque table de notre base de donnees
    // Dbset est une classe generique qui represente une table dans la base de donnees
    // Elle est responsable du mapping objet-relationnel
    

    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Medecin> Medecins => Set<Medecin>();
    public DbSet<Allergie> Allergies => Set<Allergie>();
    public DbSet<Ordonnance> Ordonnances => Set<Ordonnance>();
    public DbSet<Medicament> Medicaments => Set<Medicament>();
    public DbSet<Antecedent> Antecedents => Set<Antecedent>();


    // Constructeur
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }


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

        
        
    }


}
