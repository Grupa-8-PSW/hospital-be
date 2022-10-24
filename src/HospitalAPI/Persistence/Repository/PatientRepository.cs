using HospitalLibrary.Patient;

namespace HospitalAPI.Persistence.Repository
{
    public class PatientRepository : BaseEntityModelRepository<Patient>, IPatientRepository
    {

        public PatientRepository(HospitalDbContext dbContext) : base(dbContext)
        {

        }

    }
}
