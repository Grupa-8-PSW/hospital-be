using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
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
        IEnumerable<BloodBankNews> GetAllPublished();
        void Create(BloodBankNewsMessageDTO bloodBankNewsDTO);
        BloodBankNews GetById(int id);
        public void Delete(BloodBankNews bloodBankNews);
        void ArchiveNews(BloodBankNews bloodBankNews);
        void PublishNews(BloodBankNews bloodBankNews);
    }
}
