using IntegrationLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Repository.Interfaces
{
    public interface IBloodBankNewsRepository
    {
        IEnumerable<BloodBankNews> GetAll();
        IEnumerable<BloodBankNews> GetAllPublished();
        void Create(BloodBankNews bloodBankNews);
        BloodBankNews GetById(int id);
        void Delete(BloodBankNews bloodBankNews);
        void Update(BloodBankNews bloodBankNews);
    }
}
