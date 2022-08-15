using Domain.Common;
using LAHub.Domain.OpenReferralEnities;

namespace LAHub.Domain.Events;

public class OpenReferralServiceCreatedEvent : BaseEvent
{
    public OpenReferralServiceCreatedEvent(OpenReferralService item)
    {
        Item = item;
    }

    public OpenReferralService Item { get; }
}
