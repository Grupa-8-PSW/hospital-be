using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
<<<<<<< HEAD
    public interface IBloodBankService
    {
        IEnumerable<BloodBank> GetAll();
=======
    internal interface IBloodBankService
    {
>>>>>>> 7cd19fb14d5fce0b3579bc2d0c9d6275d0d71fb8
        void Create(BloodBank bloodBank);
    }
}
