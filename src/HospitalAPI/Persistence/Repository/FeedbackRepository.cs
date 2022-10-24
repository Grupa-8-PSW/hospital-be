﻿using HospitalLibrary.Feedback;

namespace HospitalAPI.Persistence.Repository
{
    public class FeedbackRepository : BaseEntityModelRepository<Feedback>, IFeedbackRepository
    {

        public FeedbackRepository(HospitalDbContext dbContext) : base(dbContext)
        {

        }

    }
}
