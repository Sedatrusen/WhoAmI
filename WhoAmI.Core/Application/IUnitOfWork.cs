using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Core.Domain;

namespace WhoAmI.Core.Application
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity,TId> Repository<TEntity,TId>() where TEntity : BaseAuditableEntity<TId>;
        Task<int> Save(CancellationToken cancellationToken);
        Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys);
        Task Rollback();
        IGenericRepository<TEntity, TId> Repository<TEntity, TId>() where TEntity : BaseAuditableEntity<TId>;
    }
}
