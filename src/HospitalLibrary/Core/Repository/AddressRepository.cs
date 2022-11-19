using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public class AddressRepository : BaseEntityModelRepository<Address>, IAddressRepository
    {
        public AddressRepository(HospitalDbContext dbContext) : base(dbContext)
        {

        }
    }
}
