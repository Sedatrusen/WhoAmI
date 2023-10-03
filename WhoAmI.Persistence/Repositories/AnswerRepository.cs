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
    public class AnswerRepository : IAnswerRepository
    {
        private readonly IGenericRepository<Answer> _repository;

        public AnswerRepository(IGenericRepository<Answer> repository)
        {
            _repository = repository;
        }

        public async Task<List<Answer>> GetAnswerByQuesitonId(int id)
        {
            return await _repository.Entities.Where(x=> x.QuestionId == id ).ToListAsync();
        }
    }
}
