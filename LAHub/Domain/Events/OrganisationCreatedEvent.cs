using LAHub.Domain.Entities;

namespace LAHub.Domain.Events;

public class OrganisationCreatedEvent : BaseEvent
{
    public OrganisationCreatedEvent(Organisation item)
    {
        Item = item;
    }

    public Organisation Item { get; }
}
