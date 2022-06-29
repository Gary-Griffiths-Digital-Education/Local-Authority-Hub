using LAHub.Domain.Entities;

namespace LAHub.Domain.DbEntities;

public sealed class EligibilityDto : Eligibility
{
    public EligibilityDto() : base(Guid.NewGuid(), null, null) { }
}
