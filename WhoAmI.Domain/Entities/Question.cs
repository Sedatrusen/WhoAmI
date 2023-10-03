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
        public required string Body { get; set; }
        public required Collection<Answer> Answers {  get; set; }
     
               

        

    }
}
