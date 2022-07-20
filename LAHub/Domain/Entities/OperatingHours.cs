namespace LAHub.Domain.Entities
{
    public class OperatingHours : BaseAuditableEntity<Guid>
    {
        private OperatingHours()
        {
        }
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

        public Guid ServiceId { get; private set; }

        public Guid ServiceLocationId { get; private set; }

        public string? Description { get; private set; }
    }
}
