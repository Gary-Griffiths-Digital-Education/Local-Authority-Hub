namespace LAHub.Domain.OpenReferralEnities;

public class OpenReferralFunding
{
    private OpenReferralFunding() { }
    public OpenReferralFunding(string id, string source)
    {
        Id = id;
        Source = source;
    }

    public string Id { get; init; } = default!;
    public string Source { get; init; } = default!;
}
