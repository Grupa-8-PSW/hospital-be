using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Core.Model;

namespace IntegrationLibrary.Core.Repository.Interfaces
{
    public interface IBloodBankRepository
    {
        IEnumerable<BloodBank> GetAll();
        void Create(BloodBank bloodBank);
        BloodBank GetById(int id);
        void Delete(BloodBank bloodBank);
        BloodBank GetByApiKey(string apiKey);
        BloodBank getByName(string bloodBankName);
    }
}
