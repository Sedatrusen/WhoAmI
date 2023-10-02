using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Core.Domain;
using WhoAmI.Domain.Entities;

namespace WhoAmI.Application.Features.MyUsers.Commands
{ public class MyUserCreatedEvent : BaseEvent
    {
        public MyUser myUser { get; }
        public MyUserCreatedEvent(
          MyUser myUser) {
        this.myUser = myUser;
        }

    }
}
