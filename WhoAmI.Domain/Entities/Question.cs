using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Core.Domain;

namespace WhoAmI.Domain.Entities
{
    public class Question : BaseAuditableEntity
    {
        public  string Body { get; set; }
        public  Collection<Answer> Answers {  get; set; }
     
        public  int QuizId { get; set; }

        

    }
}
