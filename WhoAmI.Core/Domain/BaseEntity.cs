using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoAmI.Core.Domain
{


    public abstract class BaseEntity : IEntity<int>
    {
        private readonly List<BaseEvent> _domainEvents = new();
        public int Id { get; set; }

        [NotMapped]
        public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(BaseEvent domainEvent) => _domainEvents.Add(domainEvent);
        public void RemoveDomainEvent(BaseEvent domainEvent) => _domainEvents.Remove(domainEvent);
        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}
