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
    public class QuizResultRepository : IQuizResultRepository
    {
        private readonly IGenericRepository<QuizResult> _repository;

        public QuizResultRepository(IGenericRepository<QuizResult> repository)
        {
            _repository = repository;
        }

        public async Task<List<QuizResult>> GetAllQuizResultsByQuizIdAsync(int id)
        {
            return await _repository.Entities.Where(x => x.QuizId == id).ToListAsync();
        }
    }
}
