using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoAmI.Core.Domain
{
    public interface IDomainEventDispatcher
    {
        Task DispatchAndClearEvents(IEnumerable<BaseEntity> entitiesWithEvents);
    }
}
