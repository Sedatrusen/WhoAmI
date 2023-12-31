﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Domain.Entities;

namespace WhoAmI.Application.Repositories
{
    public interface IQuizResultRepository
    {
        public Task<List<QuizResult>> GetAllQuizResultsByQuizIdAsync(int id);
    }
}
