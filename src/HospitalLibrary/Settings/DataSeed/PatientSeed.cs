using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Settings.DataSeed
{
    public static class PatientSeed
    {
        public static void SeedPatient(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasData(
                new Patient(1, "Pera", "Peric", "peraperic@gmail.com", "2201000120492", Core.Enums.Gender.MALE, Core.Enums.BloodType.ZERO_POSITIVE),
                new Patient(2, "Marko", "Markovic", "markomarkovic@gmail.com", "1412995012451", Core.Enums.Gender.MALE, Core.Enums.BloodType.AB_NEGATIVE),
                new Patient(3, "Dusan", "Baljinac", "dusanbaljinac@gmail.com", "2008004124293", Core.Enums.Gender.MALE, Core.Enums.BloodType.B_NEGATIVE),
                new Patient(4, "Slobodan", "Radulovic", "slobodanradulovic@gmail.com", "1111978020204", Core.Enums.Gender.MALE, Core.Enums.BloodType.A_NEGATIVE),
                new Patient(5, "Mika", "Mikic", "mikamikic@gmail.com", "1234567891111", Core.Enums.Gender.MALE, Core.Enums.BloodType.ZERO_POSITIVE),
                new Patient(6, "Ana", "Anic", "anaanic@gmail.com", "1234567892222", Core.Enums.Gender.FEMALE, Core.Enums.BloodType.AB_NEGATIVE),
                new Patient(7, "Andjela", "Andjelic", "andjelaandjelic@gmail.com", "1234567893333", Core.Enums.Gender.FEMALE, Core.Enums.BloodType.B_NEGATIVE),
                new Patient(8, "Slobodan", "Slobic", "slobodanslobic@gmail.com", "1234567894444", Core.Enums.Gender.MALE, Core.Enums.BloodType.A_NEGATIVE));
        }
    }
}
