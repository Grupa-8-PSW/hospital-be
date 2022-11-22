using IntegrationLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.Interfaces
{
    public interface IBloodConsumptionConfigurationService
    {
        public BloodConsumptionConfiguration Create(BloodConsumptionConfiguration bloodConsumptionConfiguration);

        public List<BloodConsumptionConfiguration> GetAll();

        public byte[] GeneratePdf(BloodConsumptionConfiguration bs, List<BloodUnit2> bloodUnits);


        public BloodConsumptionConfiguration FindActiveConfiguration();
        public List<BloodUnit2> FindValidBloodUnits(List<BloodUnit2> bloodUnits, out List<BloodConsumptionConfiguration> configuration);

        public void Update(BloodConsumptionConfiguration newBloodConsumptionConfiguration);

    }
}
