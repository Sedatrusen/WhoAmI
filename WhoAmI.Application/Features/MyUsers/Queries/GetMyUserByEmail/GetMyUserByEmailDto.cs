using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Application.Common.Mappings;
using WhoAmI.Domain.Entities;
using WhoAmI.Domain.Enums;

namespace WhoAmI.Application.Features.MyUsers.Queries.GetMyUserByEmail
{
    public class GetMyUserByEmailDto : IMapFrom<MyUser>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public Collection<Quiz>? Quizzes { get; set; }
        public UserType UserType { get; set; }
    }
}
