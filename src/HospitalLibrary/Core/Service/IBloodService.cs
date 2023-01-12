using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public interface IBloodService : IEntityService<Blood>
    {
        public void RestockBlood(int id, Blood entity);
        public List<double> GetBloodPerMonth(int year, string bloodType);

        public List<double> GetMoneyPerMonth(int year);

    }
}
