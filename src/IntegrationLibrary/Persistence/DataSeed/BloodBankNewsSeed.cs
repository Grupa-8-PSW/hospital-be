using IntegrationLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Persistence.DataSeed
{
    public static class BloodBankNewsSeed
    {
        public static void SeedBloodBankNews(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BloodBankNews>().HasData(
                new BloodBankNews() { id=1, text="text", subject="subject1", archived=false, byteArray=Array.Empty<byte>(), published=false}
            );
        }
    }
}
