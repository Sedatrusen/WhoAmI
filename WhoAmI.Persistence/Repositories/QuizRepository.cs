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
    public class QuizRepository : IQuizRepository
    {
        private readonly IGenericRepository<Quiz, int> _repository;

        public QuizRepository(IGenericRepository<Quiz, int> repository)
        {
            _repository = repository;
        }

    }
}
