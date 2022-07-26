namespace LAHub.Domain.OpenReferralEnities;

public class Funding
{
    private Funding() { }
    public Funding(string id, string source)
    {
        Id = id;
        Source = source;
    }

    public string Id { get; init; } = default!;
    public string Source { get; init; } = default!;
}
