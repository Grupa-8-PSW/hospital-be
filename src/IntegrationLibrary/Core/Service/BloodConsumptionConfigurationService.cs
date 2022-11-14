using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository;
using IntegrationLibrary.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service
{
    public class BloodConsumptionConfigurationService : IBloodConsumptionConfigurationService
    {
        private readonly IBloodConsumptionConfigurationRepository _repository;
        
        public BloodConsumptionConfigurationService(IBloodConsumptionConfigurationRepository repo)
        {
            _repository = repo;
        }

        public BloodConsumptionConfiguration Create(BloodConsumptionConfiguration bloodConsumptionConfiguration)
        {
            return _repository.Create(bloodConsumptionConfiguration);
        }

        public List<BloodConsumptionConfiguration> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
