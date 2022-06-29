using LAHub.Domain.Entities;

namespace LAHub.Domain.DbEntities;

public sealed class LocationDto : Location
{
    public LocationDto() : base(string.Empty, null, 0.0D, 0.0D) { }
}
