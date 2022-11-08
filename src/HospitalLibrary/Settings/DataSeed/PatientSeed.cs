using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Settings.DataSeed
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
