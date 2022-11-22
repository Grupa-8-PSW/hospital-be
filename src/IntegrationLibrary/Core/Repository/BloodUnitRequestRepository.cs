using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Repository
{
    public class BloodUnitRequestRepository : IBloodUnitRequestRepository
    {
        private readonly IntegrationDbContext _context;

        public BloodUnitRequestRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BloodUnitRequest> GetAll()
        {
            return _context.BloodUnitRequests.ToList();
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
    }
}
