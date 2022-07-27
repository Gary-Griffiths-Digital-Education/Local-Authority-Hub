namespace LAHub.Domain.OpenReferralEnities;

public class OpenReferralOrganisation
{
    
    private OpenReferralOrganisation()
    {
        
    }

    public OpenReferralOrganisation(string? id, string? name, string? description, string? logo, string? uri, string? url
        , ICollection<OpenReferralReview>? reviews, ICollection<OpenReferralService>? services
        )
    {
        Id = id;
        Name = name;
        Description = description;
        Logo = logo;
        Uri = uri;
        Url = url;
        Reviews = reviews;
        Services = services;
    }

    /*
    public OpenReferralOrganisation(string? id, string? name, string? description, string? logo, string? uri, string? url
        ,ICollection<Review>? reviews, ICollection<OpenReferralService>? services
        )
    {
        Id = id;
        Name = name;
        Description = description;
        Logo = logo;
        Uri = uri;
        Url = url;
        Reviews = reviews;
        Services = services;
    }
    */

    public string? Id { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
    public string? Logo { get; init; }
    public string? Uri { get; init; }
    public string? Url { get; init; }
    public virtual ICollection<OpenReferralReview>? Reviews { get; set; } = default!;
    public virtual ICollection<OpenReferralService>? Services { get; set; } = default!;


}

