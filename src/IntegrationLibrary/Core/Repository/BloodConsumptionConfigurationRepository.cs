﻿using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Repository
{
    public class BloodConsumptionConfigurationRepository : IBloodConsumptionConfigurationRepository
    {
        private readonly IntegrationDbContext _context;

        public BloodConsumptionConfigurationRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public void Create(BloodConsumptionConfiguration bloodConsumptionConfiguration)
        {
            _context.BloodConsumptionConfigurations.Add(bloodConsumptionConfiguration);
            _context.SaveChanges();
        }
    }
}
