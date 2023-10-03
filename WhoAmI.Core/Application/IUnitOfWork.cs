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
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseAuditableEntity;
        Task<int> Save(CancellationToken cancellationToken);
        Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys);
        Task Rollback();
       
    }
}
