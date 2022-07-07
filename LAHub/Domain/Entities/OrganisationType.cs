using System;
using System.Collections.Generic;
using System.Linq;
namespace LAHub.Domain.Entities
{
    public class OrganisationType : BaseAuditableEntity<Guid>
    {
        public OrganisationType() { }

        public OrganisationType(
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
