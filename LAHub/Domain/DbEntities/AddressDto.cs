using LAHub.Domain.Entities;

namespace LAHub.Domain.DbEntities;

public sealed class AddressDto : Address
{
    public AddressDto() : base(string.Empty, null, null, string.Empty) { }
}
