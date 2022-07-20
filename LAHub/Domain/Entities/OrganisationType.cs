using System;
using System.Collections.Generic;
using System.Linq;
namespace LAHub.Domain.Entities
{
    public class OrganisationType : BaseAuditableEntity<Guid>
    {
        private OrganisationType() { }

        public OrganisationType(
            string name,
            string? description
        )
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description ?? string.Empty;
        }

        public string Name { get; private set; } = string.Empty;

        public string? Description { get; private set; } = string.Empty;
    }
}
