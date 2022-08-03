using LAHub.Domain.OpenReferralEnities;

namespace LAHub.Domain.RecordEntities;

public record OpenReferralServiceDeliveryRecord
{
    private OpenReferralServiceDeliveryRecord() { }
    public OpenReferralServiceDeliveryRecord(string id, ServiceDelivery serviceDelivery)
    {
        Id = id;
        ServiceDelivery = serviceDelivery;
    }

    public string Id { get; init; } = default!;
    public ServiceDelivery ServiceDelivery { get; init; }
}
