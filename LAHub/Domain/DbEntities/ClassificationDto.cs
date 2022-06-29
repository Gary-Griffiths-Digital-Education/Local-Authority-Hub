using LAHub.Domain.Entities;

namespace LAHub.Domain.DbEntities;

public sealed class ClassificationDto : Classification
{
    public ClassificationDto() : base(string.Empty, null) { }
}
