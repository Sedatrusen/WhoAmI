using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Application.Common.Mappings;
using WhoAmI.Application.Features.Answers.Queries.GetAnswerByQuestionId;
using WhoAmI.Domain.Entities;

namespace WhoAmI.Application.Features.Questions.Queries.GetQuestionById
{
    public class GetQuesitonByQuizIdDto : IMapFrom<Question>
    {
        public int Id { get; set; }
        public required string Body { get; set; }
        public Collection<Answer> Answers { get; set; }

        public required int QuizId { get; set; }
    }
}
