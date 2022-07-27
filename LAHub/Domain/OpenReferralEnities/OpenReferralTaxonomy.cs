namespace LAHub.Domain.OpenReferralEnities;

public class OpenReferralTaxonomy
{
    private OpenReferralTaxonomy() { }
    public OpenReferralTaxonomy(string id, string name, string? vocabulary, ICollection<OpenReferralLinktaxonomycollection>? linkTaxonomyCollection,  ICollection<OpenReferralService_Taxonomy>? serviceTaxonomyCollection)
    {
        Id = id;
        LinkTaxonomyCollection = linkTaxonomyCollection;
        Name = name;
        ServiceTaxonomyCollection = serviceTaxonomyCollection;
        Vocabulary = vocabulary;
    }

    public string Id { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string? Vocabulary { get; init; }
    public virtual ICollection<OpenReferralLinktaxonomycollection>? LinkTaxonomyCollection { get; init; }  
    public virtual ICollection<OpenReferralService_Taxonomy>? ServiceTaxonomyCollection { get; init; }
    
}
