using Microsoft.Extensions.Logging;

namespace App.Shared.Domain.Models
{
    public abstract class AggregateRoot<T> : Entity<T> where T : IValueObject
    {
        private static readonly ILogger staticLog = LoggerFactory
            .Create(builder => builder.AddConsole()) // Replace this with DI in real usage
            .CreateLogger<AggregateRoot<T>>();

        private readonly List<IDomainEvent> _occurredEvents = new();

        protected AggregateRoot(T id, ILogger logger) : base(id, logger)
        {
        }

        public List<IDomainEvent> OccurredEvents()
        {
            var events = new List<IDomainEvent>(_occurredEvents);
            _occurredEvents.Clear();
            log?.LogTrace("Return occurred domain events. [numberOfEvents={Count}]", events.Count);
            return events;
        }

        protected void RaiseEvent(IDomainEvent domainEvent)
        {
            _occurredEvents.Add(domainEvent);
            log?.LogDebug("Raised new domain event. [type={Type}]", domainEvent.GetType().Name);
        }
    }
}
