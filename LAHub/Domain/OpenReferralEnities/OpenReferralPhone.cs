using Domain.Common;

namespace LAHub.Domain.OpenReferralEnities;

public class OpenReferralPhone : BaseAuditableEntity<string>
{
    private OpenReferralPhone() { }
    public OpenReferralPhone(string id, string number)
    {
        Id = id;
        Number = number;
    }

    public string Number { get; init; } = default!;
}
