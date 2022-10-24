using HospitalLibrary.Feedback;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Persistence.DataSeed
{
    public static class FeedbackSeed
    {
        public static void SeedFeedback(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback(1, 1, "Bolnica je dobra", 3, true, true, FeedbackStatus.OnHold),
                new Feedback(2, 2, "Bolnica je losa", 1, false, true, FeedbackStatus.OnHold),
                new Feedback(3, 3, "Bolnica je odlicna", 5, false, true, FeedbackStatus.Approved),
                new Feedback(4, 4, "Bolnica je solidna", 2, true, true, FeedbackStatus.OnHold));
        }

    }
}
