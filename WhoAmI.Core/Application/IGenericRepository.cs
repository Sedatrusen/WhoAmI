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
        IQueryable<TEntity> Entities { get; }

        Task<TEntity> GetByIdAsync(int id);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
