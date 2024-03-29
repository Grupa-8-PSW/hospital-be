﻿using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Model.Map;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings.DataSeed;
using Microsoft.EntityFrameworkCore;
using HospitalLibrary.Core.Model.Aggregates.AppointmentScheduling;
using HospitalLibrary.Core.Model.Aggregates.RenovationScheduling;

namespace HospitalLibrary.Settings
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<MapBuilding> MapBuildings { get; set; }
        public DbSet<MapFloor> MapFloors { get; set; }
        public DbSet<MapRoom> MapRooms { get; set; }
        public DbSet<MapForm> MapForms { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<TreatmentHistory> TreatmentHistories { get; set; }
        public DbSet<EquipmentTransfer> EquipmentTransfers { get; set; }
        public DbSet<RenovationEventWrapper> RenovationEventWrappers { get; set; }
        public DbSet<Renovation> Renovations { get; set; }
        public DbSet<Therapy> Therapies { get; set; }
        public DbSet<BloodUnit> BloodUnits { get; set; }
        public DbSet<MedicalDrugs> MedicalDrugs { get; set; }
        public DbSet<BloodUnitRequest> BloodUnitRequests { get; set; }
        public DbSet<Blood> Bloods { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Allergen> Allergens { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Consilium> Consiliums { get; set; }
        public DbSet<ExaminationDone> ExaminationsDone { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
        public DbSet<AppointmentEventWrapper> AppointmentEventWrappers { get; set; }

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MedicalDrugs>()
                .HasIndex(m => m.Code)
                .IsUnique();
            modelBuilder.Entity<Blood>()
                .HasIndex(b => b.Type)
                .IsUnique();

            modelBuilder.SeedMap();

            modelBuilder.SeedAddress();
            modelBuilder.SeedDoctor();
            modelBuilder.SeedPatient();
            modelBuilder.SeedFeedback();
            modelBuilder.SeedExamination();

            modelBuilder.SeedBed();
            modelBuilder.SeedMedicalDrugs();
            modelBuilder.SeedTreatmentHistory();
            modelBuilder.SeedBlood();
            modelBuilder.SeedTherapy();
            modelBuilder.SeedAllergen();
            modelBuilder.SeedSymptoms();

            modelBuilder.SeedConsilium();
            modelBuilder.SeedDoneExaminations();

            base.OnModelCreating(modelBuilder);

        }

    }
}