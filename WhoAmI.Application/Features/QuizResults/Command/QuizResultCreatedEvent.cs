using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Core.Domain;
using WhoAmI.Domain.Entities;

namespace WhoAmI.Application.Features.QuizResults.Command
{
    public class QuizResultCreatedEvent : BaseEvent
    {
        public QuizResult quizResult { get; set; }

        public QuizResultCreatedEvent (QuizResult quizResult)
        {
            this.quizResult = quizResult;
        }
    }
}
