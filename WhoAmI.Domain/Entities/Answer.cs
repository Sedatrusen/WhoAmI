using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Core.Domain;

namespace WhoAmI.Domain.Entities
{
    public class Answer :BaseAuditableEntity
    {
        public required string Body {  get; set; }
        public bool IsTrue { get; set; }
        public bool IsSelected { get; set; }
    }
}
