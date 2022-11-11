using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.Interfaces
{
    public class BloodBankNewsService : IBloodBankNewsService
    {
        private readonly IBloodBankNewsRepository bloodBankNewsRepository;

        public BloodBankNewsService(IBloodBankNewsRepository bloodBankNewsRepository)
        {
            this.bloodBankNewsRepository = bloodBankNewsRepository;
        }

        public void Create(BloodBankNews bloodBankNews)
        {
            bloodBankNewsRepository.Create(bloodBankNews);
        }

        public void Delete(BloodBankNews bloodBankNews)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BloodBankNews> GetAll()
        {
            return bloodBankNewsRepository.GetAll();
        }

        public BloodBankNews GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
