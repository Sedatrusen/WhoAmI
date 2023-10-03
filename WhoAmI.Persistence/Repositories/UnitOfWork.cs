using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Core.Application;
using WhoAmI.Core.Domain;
using WhoAmI.Persistence.Contexts;

namespace WhoAmI.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dpContext;
        private Hashtable _repositories;
        private bool disposed;


        public UnitOfWork(ApplicationDbContext dpContext)
        {
            _dpContext = dpContext ?? throw new ArgumentNullException(nameof(dpContext));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                if (disposing)
                {
                    _dpContext.Dispose();
                }

            }
            disposed = true;
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseAuditableEntity
        {
            if (_repositories == null)
            
                _repositories = new Hashtable();
                var type = typeof(TEntity).Name;

                if (!_repositories.ContainsKey(type))
                {
                    var repositoryType = typeof(GenericRepositoy<TEntity>);
                    var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _dpContext);
                    _repositories.Add(type, repositoryInstance);

                
                        }
            return (IGenericRepository<TEntity>)_repositories[type];
        }

        public Task Rollback()
        {
            _dpContext.ChangeTracker.Entries().ToList().ForEach(e => { e.Reload(); });
            return Task.CompletedTask;
        }

        public async Task<int> Save(CancellationToken cancellationToken)
        {
            return await _dpContext.SaveChangesAsync(cancellationToken);
        }

        public Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys)
        {
            throw new NotImplementedException();
        }
    }
}
