using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.Aggregates.AppointmentScheduling;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public class AppointmentEventWrapperRepository : BaseEntityModelRepository<AppointmentEventWrapper>, IAppointmentEventWrapperRepository
    {
        public AppointmentEventWrapperRepository(HospitalDbContext dbContext) : base(dbContext)
        {

        }

        public List<int> GetScheduledAggregates()
        {
            return _dbContext.AppointmentEventWrappers.Where(e => e.EventType == EventType.SESSION_END)
                                                      .Select(ev => ev.AggregateId).ToList();
        }
    }
}
