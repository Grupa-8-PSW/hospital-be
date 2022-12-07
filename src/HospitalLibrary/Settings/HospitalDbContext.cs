using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Model.Map;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings.DataSeed;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<Allergen> Allergens { get; set; }
        public DbSet<Address> Addresses{ get; set; }


        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedMap();
            modelBuilder.SeedAddress();
            modelBuilder.SeedPatient();
            modelBuilder.SeedFeedback();
            modelBuilder.SeedAllergen();
            // modelBuilder.SeedDoctor();
            // modelBuilder.SeedExamination();
            base.OnModelCreating(modelBuilder);
        }

    }
}