using IntegrationLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Repository
{
    public interface ITenderRepository
    {
        IEnumerable<Tender> GetAll();
        void Create(Tender tender);
        Tender GetById(int id);
        void Delete(Tender tender);
        void Update(Tender tender);
    }
}
