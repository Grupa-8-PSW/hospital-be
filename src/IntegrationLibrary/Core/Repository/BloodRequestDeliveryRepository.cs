using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository.Interfaces;
using IntegrationLibrary.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Repository
{
    public class BloodRequestDeliveryRepository : IBloodRequestDeliveryRepository
    {
        private readonly IntegrationDbContext _context;

        public BloodRequestDeliveryRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BloodRequestDelivery> GetAll()
        {
            return _context.BloodRequestDelivery.ToList();
        }

        public void SaveRequestDelivery(BloodRequestDelivery bloodRequestDelivery)
        {
            _context.Add(bloodRequestDelivery);
            _context.SaveChanges();
        }
    }
}
