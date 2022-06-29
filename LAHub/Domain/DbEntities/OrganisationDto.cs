using LAHub.Domain.Entities;

namespace LAHub.Domain.DbEntities;

public sealed class OrganisationDto : Organisation
{
    public OrganisationDto() : base(string.Empty, null, Guid.NewGuid()) { }
}
