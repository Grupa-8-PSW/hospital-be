using HospitalLibrary.Core.Enums;
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
        private readonly HospitalDbContext _context;
        public BloodRepository(HospitalDbContext dbContext): base(dbContext)
        {
            this._context = dbContext;
        }
        public Blood GetByBloodType(BloodType bloodType)
        {
            Blood blood = _dbContext.Bloods.SingleOrDefault(blood => blood.Type == bloodType);
            return blood;
        }

        public void RestockBlood(Blood blood)
        {
            Blood bloodOld = GetByBloodType(blood.Type);
            blood.Id = bloodOld.Id;
            _context.Entry(bloodOld).CurrentValues.SetValues(blood);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

    }
}
