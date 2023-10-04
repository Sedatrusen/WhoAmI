using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Core.Domain;
using WhoAmI.Domain.Entities;

namespace WhoAmI.Application.Features.Quizs.Command
{
    public  class QuizCreatedEvent :BaseEvent
    {
         public Quiz quiz { get; set; }

        public QuizCreatedEvent(Quiz quiz)
        {
            this.quiz = quiz;
        }
    }
}
