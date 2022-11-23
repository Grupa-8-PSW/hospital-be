using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Settings.DataSeed
{
    public static class TherapySeed
    {
        public static void SeedTherapy(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Therapy>().HasData(
                new Therapy()
                {
                    Id = 1,
                    WhenPrescribed = DateTime.UtcNow,
                    Amount = 1,
                    Reason = "Headache",
                    TherapyType = TherapyType.MEDICAL_DRUG_THERAPY,
                    TherapySubject = "Bromazepam 500mg",
                    DoctorId = 1,
                    TreatmentHistoryId = 1
                },
                new Therapy()
                {
                    Id = 2,
                    WhenPrescribed = DateTime.UtcNow,
                    Amount = 1,
                    Reason = "Blood loss",
                    TherapyType = TherapyType.BLOOD_THERAPY,
                    TherapySubject = "A+ 500ml",
                    DoctorId = 2,
                    TreatmentHistoryId = 1
                }
            );
        }
    }
}
