using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Application.Repositories;
using WhoAmI.Core.Application;
using WhoAmI.Domain.Entities;

namespace WhoAmI.Persistence.Repositories
{
    public class MyUserRepository : IMyUserRepository
    {
        private readonly IGenericRepository<MyUser> _repository;

        public MyUserRepository(IGenericRepository<MyUser> repository)
        {
            _repository = repository;
        }

        public async Task<MyUser> GetMyUserByEmailAsync(string email)
        {
           return await _repository.Entities.Where(x => x.Mail == email).FirstAsync();
                }
    }
}
