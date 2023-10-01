using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Core.Domain;
using WhoAmI.Domain.Enums;

namespace WhoAmI.Domain.Entities
{
    public  class Quiz : BaseAuditableEntity<int>
    {
        public Guid UserId { get; set; }
        public required Collection<Question> Questions { get; set; }
        public QuizType QuizType { get; set; }
    }
}
