using Domain.Common;

namespace LAHub.Domain.OpenReferralEnities;

public class OpenReferralService_Taxonomy : BaseAuditableEntity<string>
{
    private OpenReferralService_Taxonomy() { }
    public OpenReferralService_Taxonomy(string id, string? linkId, OpenReferralTaxonomy? taxonomy)
    {
        Id = id;
        LinkId = linkId;
        Taxonomy = taxonomy;
    }
    public string? LinkId { get; init; }
    public OpenReferralTaxonomy? Taxonomy { get; init; }
}
