namespace LAHub.Domain.OpenReferralEnities;

public class OpenReferralContact
{
    private OpenReferralContact() { }
    public OpenReferralContact(string id, string title, string name)
    {
        Id = id;
        Title = title;
        Name = name;
    }

    public string Id { get; init; } = default!;
    public string Title { get; init; } = default!;
    public string Name { get; init; } = default!;
    public virtual ICollection<OpenReferralPhone>? Phones { get; set; }
    
}
