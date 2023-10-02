using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Core.Domain;
using WhoAmI.Domain.Entities;

namespace WhoAmI.Persistence.Contexts
{
    public class ApplicationDbContext<TId> : DbContext
    {
        private readonly IDomainEventDispatcher<TId> _dispatcher;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext<TId>> options,IDomainEventDispatcher<TId> dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public DbSet<MyUser> myUsers => Set<MyUser>();
        public DbSet<Quiz> quizs => Set<Quiz>();
        public DbSet<Question> questions => Set<Question>();    
        public DbSet<Answer> answers => Set<Answer>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            if (_dispatcher == null) return result;

            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity<TId>>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .ToArray();

            await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }

    }
}
