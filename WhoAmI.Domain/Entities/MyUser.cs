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
    public class MyUser : BaseAuditableEntity
    {
        public  string Name { get; set; }
        public  string Surname { get; set; }
        public  string Mail { get; set; }
        public string Password { get; set; }

        public  Collection<Quiz>? Quizzes { get; set; }
        public UserType UserType { get; set; }
      
    }
}
