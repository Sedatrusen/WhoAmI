using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Core.Application;
using WhoAmI.Domain.Entities;

namespace WhoAmI.Application.Repositories
{
    internal interface IMyUserRepositery : IGenericRepository<MyUser,Guid>
    {
    }
}
