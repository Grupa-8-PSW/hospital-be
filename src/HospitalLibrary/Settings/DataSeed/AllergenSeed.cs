﻿using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Settings.DataSeed
{
    public static class AllergenSeed
    {
        public static void SeedAllergen(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Allergen>().HasData(
                new Allergen(1, "Penicilin"),
                new Allergen(2, "Sulfonamidi "),
                new Allergen(3, "Salicilna kiselina"));

        }
    }
}
