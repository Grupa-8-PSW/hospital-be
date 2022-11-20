using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Settings.DataSeed
{
    public static class TreatmentHistorySeed
    {
        public static void SeedTreatmentHistory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TreatmentHistory>().HasData(
               new TreatmentHistory() { Id = 1, StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow, Active = true, DischargeReason = "abc", PatientId = 1, BedId = 1, Reason = null },
                new TreatmentHistory() { Id = 2, StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow, Active = true, DischargeReason = "abc", PatientId = 2, BedId = 2, Reason = null },
                new TreatmentHistory() { Id = 3, StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow, Active = true, DischargeReason = "abc", PatientId = 3, BedId = 3, Reason = null });

        }
    }
}
