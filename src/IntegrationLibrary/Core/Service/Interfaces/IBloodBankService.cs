using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Core.Model;

namespace IntegrationLibrary.Core.Service.Interfaces
{
    public interface IBloodBankService
    {
        IEnumerable<BloodBank> GetAll();
        void Create(BloodBank bloodBank);
        BloodBank GetById(int id);
        public void Delete(BloodBank bloodBank);
    }
}
