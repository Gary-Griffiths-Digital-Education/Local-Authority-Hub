namespace LAHub.Domain.OpenReferralEnities;

public class Accessibility_For_Disabilities
{
    private Accessibility_For_Disabilities() { }
    public Accessibility_For_Disabilities(string id, string accessibility)
    {
        Id = id;
        Accessibility = accessibility;
    }

    public string Id { get; init; } = default!;
    public string Accessibility { get; init; } = default!;

}
