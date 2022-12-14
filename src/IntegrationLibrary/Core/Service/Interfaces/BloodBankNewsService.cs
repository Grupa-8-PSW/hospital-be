using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
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
        private readonly IBloodBankRepository bloodBankRepository;

        public BloodBankNewsService(IBloodBankNewsRepository bloodBankNewsRepository, IBloodBankRepository bloodBankRepository)
        {
            this.bloodBankNewsRepository = bloodBankNewsRepository;
            this.bloodBankRepository = bloodBankRepository;
        }

        public void ArchiveNews(BloodBankNews bloodBankNews)
        {
            bloodBankNews.Archived = true;
            bloodBankNewsRepository.Update(bloodBankNews);
        }

        public void PublishNews(BloodBankNews bloodBankNews)
        {
            bloodBankNews.Published = true;
            bloodBankNewsRepository.Update(bloodBankNews);
        }

        public void Create(BloodBankNewsMessageDTO bloodBankNewsDTO)
        {
            BloodBank bloodBank = bloodBankRepository.GetByApiKey(bloodBankNewsDTO.bloodBankApiKey);
            if (bloodBank != null)
            {
                BloodBankNews bloodBankNews = new BloodBankNews(bloodBankNewsDTO.text, bloodBankNewsDTO.subject, 
                                                                bloodBankNewsDTO.imgSrc, false, false, bloodBank, bloodBank.Id);
                bloodBankNewsRepository.Create(bloodBankNews);
            }
            
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
            return bloodBankNewsRepository.GetById(id);
        }

        
    }
}
