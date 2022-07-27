namespace LAHub.Domain.OpenReferralEnities;

public class OpenReferralLinktaxonomycollection
{
    private OpenReferralLinktaxonomycollection() { }
    public OpenReferralLinktaxonomycollection(string id, string link_id, string link_type)
    {
        Id = id;
        Link_id = link_id;
        Link_type = link_type;
    }
    public string Id { get; init; } = default!;
    public string Link_id { get; init; } = default!;
    public string Link_type { get; init; } = default!;
}
