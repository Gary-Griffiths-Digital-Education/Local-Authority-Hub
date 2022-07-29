using LAHub.Domain.OpenReferralEnities;

namespace LAHub.Domain.Events;

public class OpenReferralReviewCreatedEvent : BaseEvent
{
    public OpenReferralReviewCreatedEvent(OpenReferralReview item)
    {
        Item = item;
    }

    public OpenReferralReview Item { get; }
}