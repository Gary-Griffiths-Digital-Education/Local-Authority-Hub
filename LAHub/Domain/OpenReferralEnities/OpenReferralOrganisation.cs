namespace LAHub.Domain.OpenReferralEnities;

public class OpenReferralOrganisation : BaseEntity<string>
{
    
    private OpenReferralOrganisation()
    {
        
    }

    public OpenReferralOrganisation(string id, string? name, string? description, string? logo, string? uri, string? url
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

    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public string? Logo { get; private set; }
    public string? Uri { get; private set; }
    public string? Url { get; private set; }
    public virtual ICollection<OpenReferralReview>? Reviews { get; set; } = default!;
    public virtual ICollection<OpenReferralService>? Services { get; set; } = default!;

    public void Update(OpenReferralOrganisation openReferralOrganisation)
    {
        Name = openReferralOrganisation.Name;
        Description = openReferralOrganisation.Description;
        Logo = openReferralOrganisation.Logo;
        Uri = openReferralOrganisation.Uri;
        Url = openReferralOrganisation.Url;
    }


}

