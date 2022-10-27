using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Core.Model;

namespace IntegrationLibrary.Core.Repository
{
    public interface IBloodBankRepository
    {
        IEnumerable<BloodBank> GetAll();
        void Create(BloodBank bloodBank);
    }
}
