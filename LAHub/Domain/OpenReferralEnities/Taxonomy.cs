namespace LAHub.Domain.OpenReferralEnities;

public class Taxonomy
{
    private Taxonomy() { }
    public Taxonomy(string id, string name, string? vocabulary, ICollection<Linktaxonomycollection>? linkTaxonomyCollection,  ICollection<Service_Taxonomy>? serviceTaxonomyCollection)
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
    public virtual ICollection<Linktaxonomycollection>? LinkTaxonomyCollection { get; init; }  
    public virtual ICollection<Service_Taxonomy>? ServiceTaxonomyCollection { get; init; }
    
}
