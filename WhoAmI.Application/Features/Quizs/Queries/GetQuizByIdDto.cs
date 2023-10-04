using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Application.Common.Mappings;
using WhoAmI.Application.Features.Answers.Queries.GetAnswerByQuestionId;
using WhoAmI.Application.Features.Questions.Queries.GetQuestionById;
using WhoAmI.Domain.Entities;
using WhoAmI.Domain.Enums;

namespace WhoAmI.Application.Features.Quizs.Queries
{
    public class GetQuizByIdDto :IMapFrom<Quiz>
    {
        public int UserId { get; set; }
        public Collection<Question> Questions { get; set; }
        public QuizType QuizType { get; set; }
    }
}
