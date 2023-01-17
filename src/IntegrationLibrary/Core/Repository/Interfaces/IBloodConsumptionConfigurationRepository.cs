using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Repository.Interfaces
{
    public interface IBloodConsumptionConfigurationRepository
    {
        public BloodConsumptionConfiguration Create(BloodConsumptionConfiguration bloodConsumptionConfiguration);

        public BloodConsumptionConfiguration FindActiveConfiguration();
        List<BloodConsumptionConfiguration> GetAll();
        public void Update(BloodConsumptionConfiguration newBloodConsumptionConfiguration);



    }
}
