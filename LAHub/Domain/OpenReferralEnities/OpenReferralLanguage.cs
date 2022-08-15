using Domain.Common;

namespace LAHub.Domain.OpenReferralEnities;

public class OpenReferralLanguage : BaseAuditableEntity<string>
{
    private OpenReferralLanguage() { }
    public OpenReferralLanguage(string id, string language)
    {
        Id = id;
        Language = language;
    }
    public string Language { get; init; } = default!;
}
