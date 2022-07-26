namespace LAHub.Domain.OpenReferralEnities;

public class EligibilityItem
{
    private EligibilityItem() { }
    public EligibilityItem(string id, string eligibility, string? linkId, int maximum_age, int minimum_age, ICollection<Taxonomy>? taxonomys)
    {
        Id = id;
        Eligibility = eligibility;
        LinkId = linkId;
        Maximum_age = maximum_age;
        Minimum_age = minimum_age;
        taxonomys = Taxonomys;
    }

    public string Id { get; init; } = default!;
    public string Eligibility { get; init; } = default!;
    public string? LinkId { get; init; }
    public int Maximum_age { get; init; }
    public int Minimum_age { get; init; }
    public virtual ICollection<Taxonomy>? Taxonomys { get; init; }
}
