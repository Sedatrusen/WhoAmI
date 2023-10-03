using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Domain.Entities;

namespace WhoAmI.Application.Features.Questions.Queries.GetQuestionById
{
    public class GetQuesitonByQuizIdDto
    {
        public int Id { get; set; }
        public required string Body { get; set; }
        public required Collection<Answer> Answers { get; set; }

        public required int QuizId { get; set; }
    }
}
