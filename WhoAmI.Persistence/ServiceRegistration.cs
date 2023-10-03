using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Application.Repositories;
using WhoAmI.Core.Application;
using WhoAmI.Core.Domain;
using WhoAmI.Domain.Entities;
using WhoAmI.Persistence.Contexts;
using WhoAmI.Persistence.Repositories;

namespace WhoAmI.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        { var connectionString = configuration.GetConnectionString("DefaultConnection");

           
            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(connectionString,
                  builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
                      .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepositoy<>))
            .AddTransient<IMediator, Mediator>()
                .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>()
                     .AddTransient<IMyUserRepository, MyUserRepository>()
            .AddTransient<IQuizRepository, QuizRepository>()
            .AddTransient<IQuestionRepository, QuestionRepository>()
            .AddTransient<IAnswerRepository, AnswerRepository>();



           

            return services;
        }

      
    }
}
