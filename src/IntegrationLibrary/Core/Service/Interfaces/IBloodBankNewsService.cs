using IntegrationLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.Interfaces
{
    public interface IBloodBankNewsService
    {
        IEnumerable<BloodBankNews> GetAll();
        void Create(BloodBankNews bloodBankNews);
        BloodBankNews GetById(int id);
        public void Delete(BloodBankNews bloodBankNews);
    }
}
