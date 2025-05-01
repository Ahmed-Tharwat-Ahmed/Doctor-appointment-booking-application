using Microsoft.Extensions.Logging;

namespace App.Shared.Domain.Models
{
    public abstract class Entity<T> : IDomainModel where T : IValueObject
    {
        protected readonly ILogger log;
        public T Id { get; }

        protected Entity(T id, ILogger logger)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            log = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            var otherEntity = (Entity<T>)obj;
            return Id.Equals(otherEntity.Id);
        }
    }
}
