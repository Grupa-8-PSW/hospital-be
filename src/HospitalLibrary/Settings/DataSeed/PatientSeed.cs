﻿using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Settings.DataSeed
{
    public static class PatientSeed
    {
        public static void SeedPatient(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasData(
                new Patient(1, "Pera", "Peric", "peraperic@gmail.com", "2201000120492", Core.Enums.Gender.MALE, Core.Enums.BloodType.ZERO_POSITIVE, 1, 1, 1),
                new Patient(2, "Marko", "Markovic", "markomarkovic@gmail.com", "1412995012451", Core.Enums.Gender.MALE, Core.Enums.BloodType.AB_NEGATIVE, 2, 2, 1),
                new Patient(3, "Dusan", "Baljinac", "dusanbaljinac@gmail.com", "2008004124293", Core.Enums.Gender.MALE, Core.Enums.BloodType.B_NEGATIVE, 3, 1, 1),
                new Patient(4, "Slobodan", "Radulovic", "slobodanradulovic@gmail.com", "1111978020204", Core.Enums.Gender.MALE, Core.Enums.BloodType.A_NEGATIVE, 4, 2, 1));
        }
    }
}
