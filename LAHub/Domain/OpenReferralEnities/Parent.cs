namespace LAHub.Domain.OpenReferralEnities;

public class Parent
{
    private Parent() { }
    public Parent(string id, string name, string? vocabulary, ICollection<Service_Taxonomy>? serviceTaxonomyCollection, ICollection<Linktaxonomycollection>? linkTaxonomyCollection)
    {
        Id = id;
        Name = name;
        Vocabulary = vocabulary;
        ServiceTaxonomyCollection = serviceTaxonomyCollection;
        LinkTaxonomyCollection = linkTaxonomyCollection;
    }

    public string Id { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string? Vocabulary { get; init; }
    public virtual ICollection<Service_Taxonomy>? ServiceTaxonomyCollection { get; init; } 
    public virtual ICollection<Linktaxonomycollection>? LinkTaxonomyCollection { get; init; }
}
