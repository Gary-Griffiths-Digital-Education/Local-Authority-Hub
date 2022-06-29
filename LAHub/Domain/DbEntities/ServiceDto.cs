using LAHub.Domain.Entities;

namespace LAHub.Domain.DbEntities;

public sealed class ServiceDto : Service
{
    public ServiceDto() : base(string.Empty, null, Guid.NewGuid()) { }
}
