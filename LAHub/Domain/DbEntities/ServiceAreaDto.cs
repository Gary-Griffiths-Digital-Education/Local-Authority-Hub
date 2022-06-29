using LAHub.Domain.Entities;

namespace LAHub.Domain.DbEntities;

public sealed class ServiceAreaDto : ServiceArea
{
    public ServiceAreaDto() : base(Guid.NewGuid(), null, null) { }
}
