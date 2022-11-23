using IntegrationLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Core.Model.DTO;

namespace IntegrationLibrary.Core.Service.Interfaces
{
    public interface IBloodConsumptionConfigurationService
    {
        public BloodConsumptionConfiguration Create(BloodConsumptionConfiguration bloodConsumptionConfiguration);

        public List<BloodConsumptionConfiguration> GetAll();

        public byte[] GeneratePdf(BloodConsumptionConfiguration bs, List<BloodUnitDTO> bloodUnits);


        public BloodConsumptionConfiguration FindActiveConfiguration();
        public List<BloodUnitDTO> FindValidBloodUnits(List<BloodUnitDTO> bloodUnits, out List<BloodConsumptionConfiguration> configuration);

        public void Update(BloodConsumptionConfiguration newBloodConsumptionConfiguration);

    }
}
