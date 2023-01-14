using IntegrationLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Repository.Interfaces
{
    public interface IBloodRequestDeliveryRepository
    {
        void SaveRequestDelivery(BloodRequestDelivery bloodRequestDelivery);

        IEnumerable<BloodRequestDelivery> GetAll();
    }
}
