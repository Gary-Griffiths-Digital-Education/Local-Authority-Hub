using LAHub.Domain.Entities;

namespace LAHub.Domain.DbEntities;

public sealed class ServiceLocationDto : ServiceLocation
{
    public ServiceLocationDto() : base(Guid.NewGuid(), Guid.NewGuid()) { }
}
