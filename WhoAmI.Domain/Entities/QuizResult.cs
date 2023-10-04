using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Core.Domain;

namespace WhoAmI.Domain.Entities
{
    public class QuizResult : BaseAuditableEntity
    {
        public string AnswererName { get; set; }
        public int TrueAnswer {  get; set; }
        public int FalseAnswer { get; set; }
        public int QuizId { get; set; }
    }
}
