using Domain.Common;

namespace LAHub.Domain.OpenReferralEnities;

public class OpenReferralServiceDeliveryEx : BaseAuditableEntity<string>
{
    private OpenReferralServiceDeliveryEx() { }
    public OpenReferralServiceDeliveryEx(string id, ServiceDelivery serviceDelivery)
    {
        Id = id;
        ServiceDeliveryEx = serviceDelivery;
    }

    public ServiceDelivery ServiceDeliveryEx { get; private set; }
}
