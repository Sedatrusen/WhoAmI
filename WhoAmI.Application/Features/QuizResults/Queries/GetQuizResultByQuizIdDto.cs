using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Application.Common.Mappings;
using WhoAmI.Domain.Entities;

namespace WhoAmI.Application.Features.QuizResults.Queries
{
    public class GetQuizResultByQuizIdDto : IMapFrom<QuizResult>
    {
        public string AnswererName { get; set; }
        public int TrueAnswer { get; set; }
        public int FalseAnswer { get; set; }
        public int QuizId { get; set; }
    }
}
