using LAHub.Domain.Common;

namespace LAHub.Domain.Entities
{
    public class ServiceLocationOperatingHours : BaseEntity
    {
        public ServiceLocationOperatingHours(
            Guid serviceId,
            Guid serviceLocationId,
            string description
        )
        {
            Id = Guid.NewGuid();
            ServiceId = serviceId;
            ServiceLocationId = serviceLocationId;
            Description = description ?? string.Empty;
        }

        public Guid ServiceId { get; }

        public Guid ServiceLocationId { get; }

        public string? Description { get; }
    }
}
