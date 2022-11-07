using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Repository
{
    public interface IBloodConsumptionConfigurationRepository
    {
        void Create(BloodConsumptionConfiguration bloodConsumptionConfiguration);

    }
}
