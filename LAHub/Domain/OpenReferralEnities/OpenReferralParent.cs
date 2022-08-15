using Domain.Common;

namespace LAHub.Domain.OpenReferralEnities;

public class OpenReferralParent : BaseAuditableEntity<string>
{
    private OpenReferralParent() { }
    public OpenReferralParent(string id, string name, string? vocabulary, ICollection<OpenReferralService_Taxonomy>? serviceTaxonomyCollection, ICollection<OpenReferralLinktaxonomycollection>? linkTaxonomyCollection)
    {
        Id = id;
        Name = name;
        Vocabulary = vocabulary;
        ServiceTaxonomyCollection = serviceTaxonomyCollection;
        LinkTaxonomyCollection = linkTaxonomyCollection;
    }
    public string Name { get; init; } = default!;
    public string? Vocabulary { get; init; }
    public virtual ICollection<OpenReferralService_Taxonomy>? ServiceTaxonomyCollection { get; init; } 
    public virtual ICollection<OpenReferralLinktaxonomycollection>? LinkTaxonomyCollection { get; init; }
}
