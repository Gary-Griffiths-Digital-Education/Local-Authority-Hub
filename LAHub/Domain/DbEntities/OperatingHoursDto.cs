using LAHub.Domain.Entities;

namespace LAHub.Domain.DbEntities;

public class OperatingHoursDto : OperatingHours
{
    public OperatingHoursDto() : base(Guid.NewGuid(), Guid.NewGuid(), string.Empty) { }
}

