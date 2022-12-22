using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Enums;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Model.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace IntegrationLibrary.Persistence.DataSeed
{
    public static class MonthlySubscriptionSeed
    {
        public static void SeedMonthlySubscription(this ModelBuilder modelBuilder)
        {
            Blood blood1 = new Blood(BloodType.A_POSITIVE, 200);
            Blood blood2 = new Blood(BloodType.B_POSITIVE, 200);
            Blood blood3 = new Blood(BloodType.AB_POSITIVE, 300);
            List<Blood> bloods = new List<Blood>
            {
                blood1,
                blood2,
                blood3
            };


            Blood blood4 = new Blood(BloodType.A_POSITIVE, 8888888);
            Blood blood5 = new Blood(BloodType.B_POSITIVE, 777777);
            Blood blood6 = new Blood(BloodType.AB_POSITIVE, 99999999);
            List<Blood> bloods1 = new List<Blood>
            {
                blood4,
                blood5,
                blood6
            };


            modelBuilder.Entity<MonthlySubscription>().HasData(
                new MonthlySubscription(1, bloods, new DateTime(2022, 12, 1).ToUniversalTime(), null, 1, SubscriptionStatus.ACCEPTED),
                new MonthlySubscription(2, bloods, new DateTime(2022, 11, 1).ToUniversalTime(), null, 2, SubscriptionStatus.ACCEPTED),
                new MonthlySubscription(3, bloods, new DateTime(2022, 10, 1).ToUniversalTime(), null, 3, SubscriptionStatus.ACCEPTED),
                new MonthlySubscription(4, bloods1, new DateTime(2022, 9, 1).ToUniversalTime(), null, 3, SubscriptionStatus.ACCEPTED),
                new MonthlySubscription(5, bloods1, new DateTime(2022, 8, 1).ToUniversalTime(), null, 4, SubscriptionStatus.ACCEPTED),
                new MonthlySubscription(6, bloods1, new DateTime(2022, 7, 1).ToUniversalTime(), null, 5, SubscriptionStatus.ACCEPTED)
                );

            
        
        
        }
    }
}
