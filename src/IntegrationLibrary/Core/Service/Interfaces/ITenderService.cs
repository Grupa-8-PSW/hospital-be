using IntegrationLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.Interfaces
{
    public interface ITenderService
    {
        IEnumerable<Tender> GetAll();
        void Create(Tender tender);
        Tender GetById(int id);
        public void Delete(Tender tender);
    }
}
