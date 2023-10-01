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
    public class MyUser : BaseAuditableEntity<Guid>
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Mail { get; set; }
        public required string Password { get; set; }

        public required Collection<Quiz> Quizzes { get; set; }
        public UserType UserType { get; set; }
      
    }
}
