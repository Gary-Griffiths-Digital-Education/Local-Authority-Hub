using Domain.Common;

namespace LAHub.Domain.OpenReferralEnities;

public class OpenReferralServiceDelivery : BaseAuditableEntity<string>
{
    private OpenReferralServiceDelivery() { }
    public OpenReferralServiceDelivery(string id, ServiceDelivery serviceDelivery)
    {
        Id = id;
        ServiceDelivery = serviceDelivery;
    }

    public ServiceDelivery ServiceDelivery { get; private set; }
}
