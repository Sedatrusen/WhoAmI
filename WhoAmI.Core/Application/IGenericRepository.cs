using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Core.Domain;

namespace WhoAmI.Core.Application
{
    public interface IGenericRepository<TEntity, TId> where TEntity : BaseEntity<TId>
    {
        ICollection<TEntity> GetAll();
   
        TEntity? FindById(TId id);
        bool Add(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
    }
}
