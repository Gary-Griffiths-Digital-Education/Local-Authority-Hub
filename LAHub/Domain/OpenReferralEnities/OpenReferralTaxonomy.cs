namespace LAHub.Domain.OpenReferralEnities;

public class OpenReferralTaxonomy : BaseEntity<string>
{
    private OpenReferralTaxonomy() { }
    public OpenReferralTaxonomy(string id, string name, string? vocabulary, string? parent
        //ICollection<OpenReferralLinktaxonomycollection>? linkTaxonomyCollection
        //ICollection<OpenReferralService_Taxonomy>? serviceTaxonomyCollection
        )
    {
        Id = id;
        //LinkTaxonomyCollection = linkTaxonomyCollection;
        Name = name;
        //ServiceTaxonomyCollection = serviceTaxonomyCollection;
        Vocabulary = vocabulary;
        Parent = parent;

    }

    public string Name { get; init; } = default!;
    public string? Vocabulary { get; init; }
    public string? Parent { get; init; }
    public virtual ICollection<OpenReferralLinktaxonomycollection>? LinkTaxonomyCollection { get; init; }  
    //public virtual ICollection<OpenReferralService_Taxonomy>? ServiceTaxonomyCollection { get; init; }
    
}
