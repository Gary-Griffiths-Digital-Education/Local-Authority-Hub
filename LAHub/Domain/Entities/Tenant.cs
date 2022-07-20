namespace LAHub.Domain.Entities
{
    public class Tenant : BaseAuditableEntity<Guid>
    {
        private Tenant() { }

        public Tenant(
                string name,
                string? description
            )
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description ?? string.Empty;
        }

        public string Name { get; private set; } = String.Empty;

        public string? Description { get; private set; } = String.Empty;
    }
}
