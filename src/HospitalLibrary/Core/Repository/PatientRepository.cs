using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;

namespace HospitalLibrary.Core.Repository
{
    public class PatientRepository : BaseEntityModelRepository<Patient>, IPatientRepository
    {

        public PatientRepository(HospitalDbContext dbContext) : base(dbContext)
        {

        }

    }
}
