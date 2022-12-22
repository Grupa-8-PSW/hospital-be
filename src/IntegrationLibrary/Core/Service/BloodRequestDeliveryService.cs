using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository.Interfaces;
using IntegrationLibrary.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service
{
    public class BloodRequestDeliveryService : IBloodRequestDeliveryService
    {
        private readonly IBloodRequestDeliveryRepository bloodRequestDeliveryRepository;

        public BloodRequestDeliveryService(IBloodRequestDeliveryRepository bloodRequestDeliveryRepository)
        {
            this.bloodRequestDeliveryRepository = bloodRequestDeliveryRepository;
        }

        public IEnumerable<BloodRequestDelivery> GetAll()
        {
            return bloodRequestDeliveryRepository.GetAll();
        }

        public void SaveRequestDelivery(BloodRequestDelivery bloodRequestDelivery)
        {
            bloodRequestDeliveryRepository.SaveRequestDelivery(bloodRequestDelivery);
        }
    }
}
