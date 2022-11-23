using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public class BloodUnitRequestRepository : IBloodUnitRequestRepository
    {
        private readonly HospitalDbContext _context;

        public BloodUnitRequestRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BloodUnitRequest> GetAll()
        {
            return _context.BloodUnitRequests.ToList().OrderBy(x => x.Id);
        }

        public BloodUnitRequest GetById(int id)
        {
            return _context.BloodUnitRequests.Find(id);
        }

        public void Create(BloodUnitRequest bloodUnitRequest)
        {
            _context.BloodUnitRequests.Add(bloodUnitRequest);
            _context.SaveChanges();
        }

        public void Update(BloodUnitRequest bloodUnitRequest)
        {

            _context.ChangeTracker.Clear();
            _context.BloodUnitRequests.Update(bloodUnitRequest);
            _context.SaveChanges();
        }
    }
}
