using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IntegrationLibrary.Core.Repository
{
    public class BloodConsumptionConfigurationRepository : IBloodConsumptionConfigurationRepository
    {
        private readonly IntegrationDbContext _context;

        public BloodConsumptionConfigurationRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public BloodConsumptionConfiguration Create(BloodConsumptionConfiguration bloodConsumptionConfiguration)
        {
            _context.BloodConsumptionConfiguration.Add(bloodConsumptionConfiguration);
            _context.SaveChanges();
            return bloodConsumptionConfiguration;
        }

        public BloodConsumptionConfiguration FindActiveConfiguration()
        {
            return _context.BloodConsumptionConfiguration.FromSqlRaw("select * from BloodConsumptionConfiguration where Id = (select max(Id) from BloodConsumptionConfiguration)").First();
        }
         
        public List<BloodConsumptionConfiguration> GetAll()
        {
            return _context.BloodConsumptionConfiguration.ToList();

        }
    }
}
