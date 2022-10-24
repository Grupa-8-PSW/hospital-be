<<<<<<< HEAD
﻿using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
=======
﻿using HospitalAPI.Persistence;
using HospitalLibrary.Core.Model;
>>>>>>> 7cd19fb14d5fce0b3579bc2d0c9d6275d0d71fb8

namespace HospitalLibrary.Core.Repository
{
    public class BloodBankRepository : IBloodBankRepository
    {
<<<<<<< HEAD
        private readonly HospitalDbContext _context;
=======
        private HospitalDbContext _context;
>>>>>>> 7cd19fb14d5fce0b3579bc2d0c9d6275d0d71fb8

        public BloodBankRepository(HospitalDbContext context)
        {
            _context = context;
        }
<<<<<<< HEAD
        public IEnumerable<BloodBank> GetAll()
        {
            return _context.BloodBanks.ToList();    
        }

        public void Create(BloodBank bloodBank)
        {
            _context.BloodBanks.Add(bloodBank);
            _context.SaveChanges();
        }

=======

        public void Create(BloodBank bloodBank)
        {
            _context.bloodBanks.Add(bloodBank);
            _context.SaveChanges();
        }
>>>>>>> 7cd19fb14d5fce0b3579bc2d0c9d6275d0d71fb8
    }
}
