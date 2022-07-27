namespace LAHub.Domain.OpenReferralEnities;

public class OpenReferralLocation
{
    private OpenReferralLocation() { }
    public OpenReferralLocation(string id, string name, string? description, int latitude, int longitude
        , ICollection<OpenReferralPhysical_Address>? physical_addresses, ICollection<Accessibility_For_Disabilities>? accessibility_for_disabilities
        , ICollection<OpenReferralServiceAtLocation>? service_at_locations
        )
    {
        Id = id;
        Name = name;
        Description = description;
        Latitude = latitude;
        Longitude = longitude;
        Physical_addresses = physical_addresses;
        Accessibility_for_disabilities = accessibility_for_disabilities;
        Service_at_locations = service_at_locations;
    }

    public string Id { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string? Description { get; init; }   
    public int Latitude { get; init; }
    public int Longitude { get; init; }
    public virtual ICollection<OpenReferralPhysical_Address>? Physical_addresses { get; init; }
    public virtual ICollection<Accessibility_For_Disabilities>? Accessibility_for_disabilities { get; init; }
    public virtual ICollection<OpenReferralServiceAtLocation>? Service_at_locations { get; init; }
}
