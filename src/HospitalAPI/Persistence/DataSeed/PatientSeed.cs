using HospitalLibrary.Patient;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Persistence.DataSeed
{
    public static class PatientSeed
    {
        public static void SeedPatient(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasData(
                new Patient(1, "Pera", "Peric"),
                new Patient(2, "Marko", "Markovic"),
                new Patient(3, "Dusan", "Baljinac"),
                new Patient(4, "Slobodan", "Radulovic"));
        }
    }
}
