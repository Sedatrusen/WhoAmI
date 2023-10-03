using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Core.Domain;
using WhoAmI.Domain.Entities;

namespace WhoAmI.Application.Features.Answers.Command
{
    public class AnswerCreatedEvent : BaseEvent
    {
        public Answer answer { get; }
        public AnswerCreatedEvent(
          Answer answer)
        {
            this.answer = answer;        }

    }
}
