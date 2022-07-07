namespace LAHub.Domain.Entities
{
    public class Tenant : BaseAuditableEntity<Guid>
    {
        public Tenant() { }

        public Tenant(
                string name,
                string? description
            )
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description ?? string.Empty;
        }

        public string Name { get; set; } = String.Empty;

        public string? Description { get; set; } = String.Empty;
    }
}
