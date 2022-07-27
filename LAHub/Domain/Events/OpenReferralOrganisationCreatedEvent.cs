using LAHub.Domain.OpenReferralEnities;

namespace LAHub.Domain.Events;

public class OpenReferralOrganisationCreatedEvent : BaseEvent
{
    public OpenReferralOrganisationCreatedEvent(OpenReferralOrganisation item)
    {
        Item = item;
    }

    public OpenReferralOrganisation Item { get; }
}
