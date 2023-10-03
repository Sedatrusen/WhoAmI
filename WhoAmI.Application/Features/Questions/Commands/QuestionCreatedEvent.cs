using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Domain.Entities;

namespace WhoAmI.Application.Features.Questions.Commands
{
     public class QuestionCreatedEvent : Core.Domain.BaseEvent
    {
        public Question question { get; }

        public QuestionCreatedEvent(Question question)
        {
            this.question = question;
        }
    }
}
