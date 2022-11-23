﻿using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Org.BouncyCastle.Crypto;

namespace HospitalLibrary.Core.Repository
{
    public class PatientRepository : BaseEntityModelRepository<Patient>, IPatientRepository
    {

        public PatientRepository(HospitalDbContext dbContext) : base(dbContext)
        {

        }

        public Patient Create(Patient p, List<Allergen> allers)
        {
            p.Allergens = allers;
            return Create(p);

        }
    }
}
