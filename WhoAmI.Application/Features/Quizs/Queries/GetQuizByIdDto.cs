using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Domain.Entities;
using WhoAmI.Domain.Enums;

namespace WhoAmI.Application.Features.Quizs.Queries
{
    public class GetQuizByIdDto
    {
        public Guid UserId { get; set; }
        public required Collection<Question> Questions { get; set; }
        public QuizType QuizType { get; set; }
    }
}
