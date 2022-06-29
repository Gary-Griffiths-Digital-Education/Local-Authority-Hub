using LAHub.Domain.Entities;

namespace LAHub.Domain.DbEntities;

public sealed class ServiceOptionCategoryDto : ServiceOptionCategory
{
    public ServiceOptionCategoryDto() : base(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()) { }
}
