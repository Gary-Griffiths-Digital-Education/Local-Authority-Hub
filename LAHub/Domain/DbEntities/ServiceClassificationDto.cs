using LAHub.Domain.Entities;

namespace LAHub.Domain.DbEntities;

public sealed class ServiceClassificationDto : ServiceClassification
{
    public ServiceClassificationDto() : base(Guid.NewGuid(), Guid.NewGuid()) { }
}
