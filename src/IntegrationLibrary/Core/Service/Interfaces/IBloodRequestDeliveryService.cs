using IntegrationLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.Interfaces
{
    public interface IBloodRequestDeliveryService
    {
        void SaveRequestDelivery(BloodRequestDelivery bloodRequestDelivery);

        IEnumerable<BloodRequestDelivery> GetAll();
    }
}
