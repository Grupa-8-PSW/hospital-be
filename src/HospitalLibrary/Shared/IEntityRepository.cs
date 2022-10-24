using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Shared
{
    public interface IEntityRepository<TEntity> where TEntity : BaseEntityModel
    {
        public List<TEntity> GetAll();
        public TEntity GetById(int id);
        public TEntity Create(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(int id);
    }
}
