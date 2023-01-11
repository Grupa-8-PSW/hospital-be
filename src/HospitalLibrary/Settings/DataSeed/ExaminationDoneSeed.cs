using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;
using HospitalLibrary.GraphicalEditor.Model;
using Microsoft.EntityFrameworkCore;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model.ValueObjects;

namespace HospitalLibrary.Settings.DataSeed
{
    public static class ExaminationDoneSeed
    {
        public static void SeedExaminationDone(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ExaminationDone>(b =>
            {
                b.HasData(new ExaminationDone() { Id = 1, ExaminationId = 1, Symptoms = new List<Symptom>(), Record = "", Prescriptions = new List<Prescription>()}
                );
            }
        );
        }
    }
}
