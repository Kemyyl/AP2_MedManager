﻿// <auto-generated />
using System;
using AP2_MedManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MedManager.MigrationsF
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("AP2_MedManager.Models.Allergie", b =>
                {
                    b.Property<int>("AllergieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AllergieId"));

                    b.Property<string>("Libelle_al")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AllergieId");

                    b.ToTable("Allergies");
                });

            modelBuilder.Entity("AP2_MedManager.Models.Antecedent", b =>
                {
                    b.Property<int>("AntecedentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AntecedentId"));

                    b.Property<string>("Libelle_a")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AntecedentId");

                    b.ToTable("Antecedents");
                });

            modelBuilder.Entity("AP2_MedManager.Models.Medecin", b =>
                {
                    b.Property<int>("MedecinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("MedecinId"));

                    b.Property<DateTime>("Date_naissance_m")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Login_m")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nom_m")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password_m")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Prenom_m")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("MedecinId");

                    b.ToTable("Medecins");
                });

            modelBuilder.Entity("AP2_MedManager.Models.Medicament", b =>
                {
                    b.Property<int>("MedicamentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("MedicamentId"));

                    b.Property<string>("Contr_indication")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Libelle_med")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("MedicamentId");

                    b.ToTable("Medicaments");
                });

            modelBuilder.Entity("AP2_MedManager.Models.Ordonnance", b =>
                {
                    b.Property<int>("OrdonnanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("OrdonnanceId"));

                    b.Property<string>("Duree_traitement")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Instructions_specifique")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("MedecinId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Posologie")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("OrdonnanceId");

                    b.HasIndex("MedecinId");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("Ordonnances");
                });

            modelBuilder.Entity("AP2_MedManager.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("PatientId"));

                    b.Property<string>("Age_p")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nom_p")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Num_secu")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Poids_p")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Prenom_p")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sexe_p")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("AllergieMedicament", b =>
                {
                    b.Property<int>("AllergiesAllergieId")
                        .HasColumnType("int");

                    b.Property<int>("MedicamentsMedicamentId")
                        .HasColumnType("int");

                    b.HasKey("AllergiesAllergieId", "MedicamentsMedicamentId");

                    b.HasIndex("MedicamentsMedicamentId");

                    b.ToTable("AllergieMedicament");
                });

            modelBuilder.Entity("AllergiePatient", b =>
                {
                    b.Property<int>("AllergiesAllergieId")
                        .HasColumnType("int");

                    b.Property<int>("PatientsPatientId")
                        .HasColumnType("int");

                    b.HasKey("AllergiesAllergieId", "PatientsPatientId");

                    b.HasIndex("PatientsPatientId");

                    b.ToTable("AllergiePatient", (string)null);
                });

            modelBuilder.Entity("AntecedentMedicament", b =>
                {
                    b.Property<int>("AntecedentsAntecedentId")
                        .HasColumnType("int");

                    b.Property<int>("MedicamentsMedicamentId")
                        .HasColumnType("int");

                    b.HasKey("AntecedentsAntecedentId", "MedicamentsMedicamentId");

                    b.HasIndex("MedicamentsMedicamentId");

                    b.ToTable("AntecedentMedicament");
                });

            modelBuilder.Entity("AntecedentPatient", b =>
                {
                    b.Property<int>("AntecedentsAntecedentId")
                        .HasColumnType("int");

                    b.Property<int>("PatientsPatientId")
                        .HasColumnType("int");

                    b.HasKey("AntecedentsAntecedentId", "PatientsPatientId");

                    b.HasIndex("PatientsPatientId");

                    b.ToTable("AntecedentPatient", (string)null);
                });

            modelBuilder.Entity("MedicamentOrdonnance", b =>
                {
                    b.Property<int>("MedicamentsMedicamentId")
                        .HasColumnType("int");

                    b.Property<int>("OrdonnancesOrdonnanceId")
                        .HasColumnType("int");

                    b.HasKey("MedicamentsMedicamentId", "OrdonnancesOrdonnanceId");

                    b.HasIndex("OrdonnancesOrdonnanceId");

                    b.ToTable("MedicamentOrdonnance");
                });

            modelBuilder.Entity("AP2_MedManager.Models.Ordonnance", b =>
                {
                    b.HasOne("AP2_MedManager.Models.Medecin", "Medecin")
                        .WithMany("Ordonnances")
                        .HasForeignKey("MedecinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AP2_MedManager.Models.Patient", "Patient")
                        .WithOne("Ordonnance")
                        .HasForeignKey("AP2_MedManager.Models.Ordonnance", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medecin");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("AllergieMedicament", b =>
                {
                    b.HasOne("AP2_MedManager.Models.Allergie", null)
                        .WithMany()
                        .HasForeignKey("AllergiesAllergieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AP2_MedManager.Models.Medicament", null)
                        .WithMany()
                        .HasForeignKey("MedicamentsMedicamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AllergiePatient", b =>
                {
                    b.HasOne("AP2_MedManager.Models.Allergie", null)
                        .WithMany()
                        .HasForeignKey("AllergiesAllergieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AP2_MedManager.Models.Patient", null)
                        .WithMany()
                        .HasForeignKey("PatientsPatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AntecedentMedicament", b =>
                {
                    b.HasOne("AP2_MedManager.Models.Antecedent", null)
                        .WithMany()
                        .HasForeignKey("AntecedentsAntecedentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AP2_MedManager.Models.Medicament", null)
                        .WithMany()
                        .HasForeignKey("MedicamentsMedicamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AntecedentPatient", b =>
                {
                    b.HasOne("AP2_MedManager.Models.Antecedent", null)
                        .WithMany()
                        .HasForeignKey("AntecedentsAntecedentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AP2_MedManager.Models.Patient", null)
                        .WithMany()
                        .HasForeignKey("PatientsPatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedicamentOrdonnance", b =>
                {
                    b.HasOne("AP2_MedManager.Models.Medicament", null)
                        .WithMany()
                        .HasForeignKey("MedicamentsMedicamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AP2_MedManager.Models.Ordonnance", null)
                        .WithMany()
                        .HasForeignKey("OrdonnancesOrdonnanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AP2_MedManager.Models.Medecin", b =>
                {
                    b.Navigation("Ordonnances");
                });

            modelBuilder.Entity("AP2_MedManager.Models.Patient", b =>
                {
                    b.Navigation("Ordonnance");
                });
#pragma warning restore 612, 618
        }
    }
}