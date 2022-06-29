using LAHub.Domain.Entities;

namespace LAHub.Domain.DbEntities;

public sealed class ServiceCategoryDto : ServiceCategory
{
    public ServiceCategoryDto() : base(Guid.NewGuid(), Guid.NewGuid()) { }
}
