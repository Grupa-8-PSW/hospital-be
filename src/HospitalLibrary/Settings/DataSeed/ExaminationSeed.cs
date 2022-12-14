using HospitalLibrary.Core.Model;
using HospitalLibrary.GraphicalEditor.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Settings.DataSeed
{
    public static class ExaminationSeed
    {
        public static void SeedExamination(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Examination>().HasData(
                new Examination() { Id = 1, DoctorId = 1, PatientId = 1, RoomId = 1, StartTime = DateTime.UtcNow, Duration = 20 }
                
                );            
        }
    }
}