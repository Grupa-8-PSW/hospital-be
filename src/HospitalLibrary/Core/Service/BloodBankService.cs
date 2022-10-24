using HospitalLibrary.Core.Model;
<<<<<<< HEAD
using HospitalLibrary.Core.Repository;
=======
>>>>>>> 7cd19fb14d5fce0b3579bc2d0c9d6275d0d71fb8
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
<<<<<<< HEAD
    public class BloodBankService : IBloodBankService
    {
        private readonly IBloodBankRepository _bloodBankRepository;


        public BloodBankService(IBloodBankRepository bloodBankRepository)
        {
            _bloodBankRepository = bloodBankRepository;
        }

        public void Create(BloodBank bloodBank)
        {
            _bloodBankRepository.Create(bloodBank);
        }

        public IEnumerable<BloodBank> GetAll()
        {
            return _bloodBankRepository.GetAll();
=======
    internal class BloodBankService
    {

        public void Create(BloodBank bloodBank)
        {
>>>>>>> 7cd19fb14d5fce0b3579bc2d0c9d6275d0d71fb8
        }

    }
}
