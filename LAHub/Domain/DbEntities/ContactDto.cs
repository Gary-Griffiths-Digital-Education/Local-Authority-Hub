using LAHub.Domain.Entities;

namespace LAHub.Domain.DbEntities;

public sealed class ContactDto : Contact
{
    public ContactDto() : base(Guid.NewGuid(), Guid.NewGuid(), string.Empty, null) { }
}
