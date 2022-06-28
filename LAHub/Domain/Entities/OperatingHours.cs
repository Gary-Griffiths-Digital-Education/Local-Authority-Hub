namespace LAHub.Domain.Entities
{
    public class OperatingHours : BaseAuditableEntity<Guid>
    {
        public OperatingHours(
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
