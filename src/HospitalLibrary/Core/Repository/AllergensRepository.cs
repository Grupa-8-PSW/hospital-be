using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public class AllergensRepository : BaseEntityModelRepository<Allergen>, IAllergensRepository
    {
        public AllergensRepository(HospitalDbContext dbContext) : base(dbContext)
        {

        }
        public List<Allergen> GetAllergensByDtoId(List<int> ids) => _dbContext.Allergens.Where(a => ids.Contains(a.Id)).ToList();


    }
}
