using LAHub.Domain.Entities;

namespace LAHub.Domain.DbEntities;

public sealed class ServiceOptionClassificationDto : ServiceOptionClassification
{
    public ServiceOptionClassificationDto() : base(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()) { }
}
