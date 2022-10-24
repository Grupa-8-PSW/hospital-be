using HospitalAPI.Persistence.Config;
using HospitalAPI.Persistence.DataSeed;
using HospitalLibrary.Feedback;
using HospitalLibrary.Patient;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Persistence
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        public HospitalDbContext(DbContextOptions options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PatientConfig).Assembly);
            modelBuilder.SeedPatient();
            modelBuilder.SeedFeedback();
        }

    }
}
