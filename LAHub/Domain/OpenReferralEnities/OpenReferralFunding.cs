using Domain.Common;

namespace LAHub.Domain.OpenReferralEnities;

public class OpenReferralFunding : BaseAuditableEntity<string>
{
    private OpenReferralFunding() { }
    public OpenReferralFunding(string id, string source)
    {
        Id = id;
        Source = source;
    }
    public string Source { get; init; } = default!;
}
