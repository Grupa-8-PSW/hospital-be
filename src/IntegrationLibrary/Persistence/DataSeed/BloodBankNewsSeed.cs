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
                new BloodBankNews() { Id=1, Text="text", Subject="subject1", Archived=false, ImgSrc = string.Empty, Published=false, BloodBank=null, BloodBankId=1}
            );
        }
    }
}
