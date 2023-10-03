using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Core.Application;
using WhoAmI.Core.Domain;
using WhoAmI.Persistence.Contexts;

namespace WhoAmI.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseAuditableEntity
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> Entities => _dbContext.Set<TEntity>();

        public async Task<TEntity> AddAsync(TEntity entity)
        {
           await _dbContext.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public Task DeleteAsync(TEntity entity)
        {
           _dbContext.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
           return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public Task UpdateAsync(TEntity entity)
        {
           TEntity exist = _dbContext.Set<TEntity>().Find(entity.Id);
            _dbContext.Entry(exist).CurrentValues.SetValues(entity);
            return Task.CompletedTask;
        }
    }
}
