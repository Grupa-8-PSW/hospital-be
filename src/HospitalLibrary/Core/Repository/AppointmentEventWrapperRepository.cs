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

    }
}
