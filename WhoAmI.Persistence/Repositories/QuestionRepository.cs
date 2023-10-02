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
    public  class QuestionRepository :IQuestionRepository
    {
        private readonly IGenericRepository<Question, int> _repository;

        public QuestionRepository(IGenericRepository<Question, int> repository)
        {
            _repository = repository;
        }
    }
}
