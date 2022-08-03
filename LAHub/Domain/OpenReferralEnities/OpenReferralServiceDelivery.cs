namespace LAHub.Domain.OpenReferralEnities;

public class OpenReferralServiceDelivery : BaseEntity<string>
{
    private OpenReferralServiceDelivery() { }
    public OpenReferralServiceDelivery(string id, ServiceDelivery serviceDelivery)
    {
        Id = id;
        ServiceDelivery = serviceDelivery;
    }

    public ServiceDelivery ServiceDelivery { get; private set; }
}
