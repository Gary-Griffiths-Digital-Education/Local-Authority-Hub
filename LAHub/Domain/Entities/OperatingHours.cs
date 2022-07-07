namespace LAHub.Domain.Entities
{
    public class OperatingHours : BaseAuditableEntity<Guid>
    {
        public OperatingHours()
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

        public Guid ServiceId { get; set; }

        public Guid ServiceLocationId { get; set; }

        public string? Description { get; set; }
    }
}
