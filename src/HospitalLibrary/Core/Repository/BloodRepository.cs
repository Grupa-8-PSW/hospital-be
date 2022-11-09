using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public class BloodRepository : BaseEntityModelRepository<Blood>, IBloodRepository
    {
        public BloodRepository(HospitalDbContext dbContext): base(dbContext)
        {

        }

    }
}
