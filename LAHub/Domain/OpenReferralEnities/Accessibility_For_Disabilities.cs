using Domain.Common;

namespace LAHub.Domain.OpenReferralEnities;

public class Accessibility_For_Disabilities : BaseAuditableEntity<string>
{
    private Accessibility_For_Disabilities() { }
    public Accessibility_For_Disabilities(string id, string accessibility)
    {
        Id = id;
        Accessibility = accessibility;
    }
    public string Accessibility { get; init; } = default!;

}
