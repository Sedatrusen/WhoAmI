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
using WhoAmI.Domain.Entities;
using WhoAmI.Persistence.Contexts;
using WhoAmI.Persistence.Repositories;

namespace WhoAmI.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork<>))
                      .AddTransient(typeof(IGenericRepository<MyUser, Guid>), typeof(GenericRepositoy<Guid, MyUser>))
                      .AddTransient(typeof(IGenericRepository<Quiz, int>), typeof(GenericRepositoy<int, Quiz>))
                      .AddTransient(typeof(IGenericRepository<Question, int>), typeof(GenericRepositoy<int, Question>))
                      .AddTransient(typeof(IGenericRepository<Answer, int>), typeof(GenericRepositoy<int, Answer>))
                      .AddTransient<IMyUserRepository, MyUserRepository>()
                      .AddTransient<IQuizRepository, QuizRepository>()
                      .AddTransient<IQuestionRepository, QuestionRepository>()
                      .AddTransient<IAnswerRepository, AnswerRepository>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext<int>>(options =>
               options.UseSqlServer(connectionString,
                   builder => builder.MigrationsAssembly(typeof(ApplicationDbContext<int>).Assembly.FullName)));
            services.AddDbContext<ApplicationDbContext<Guid>>(options =>
              options.UseSqlServer(connectionString,
                  builder => builder.MigrationsAssembly(typeof(ApplicationDbContext<Guid>).Assembly.FullName)));


            return services;
        }

      
    }
}
