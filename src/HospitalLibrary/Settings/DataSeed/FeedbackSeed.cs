using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Settings.DataSeed
{
    public static class FeedbackSeed
    {
        public static void SeedFeedback(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback(1, 1, "Bolnica je dobra", true, true, FeedbackStatus.OnHold),
                new Feedback(2, 2, "Bolnica je losa", false, true, FeedbackStatus.OnHold),
                new Feedback(3, 3, "Bolnica je odlicna", false, true, FeedbackStatus.Approved),
                new Feedback(4, 4, "Bolnica je solidna", true, true, FeedbackStatus.OnHold));
        }

    }
}
