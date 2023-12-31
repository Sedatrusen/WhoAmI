﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Application.Common.Mappings;
using WhoAmI.Domain.Entities;

namespace WhoAmI.Application.Features.Answers.Queries.GetAnswerByQuestionId
{
    public class GetAnswerByQuestionIdDto : IMapFrom<Answer>
    {
        public required string Body { get; set; }
        public bool IsTrue { get; set; }
        public bool IsSelected { get; set; }

        public int QuestionId { get; set; }
    }
}
