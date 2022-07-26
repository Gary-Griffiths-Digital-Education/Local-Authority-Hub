namespace LAHub.Domain.OpenReferralEnities;

public class OpenReferralService
{
    private OpenReferralService() { }

    public OpenReferralService(string id, string name, string? description, string? accreditations, DateTime? assured_date, string? attending_access, string? attending_type, string? deliverable_type, string? status, string? url, string? email, string? fees
        , ICollection<EligibilityItem>? eligibilitys, ICollection<Funding>? fundings
        , ICollection<Holiday_Schedule>? holiday_schedules
        , ICollection<LanguageItem>? languages
        , ICollection<Regular_Schedule>? regular_schedules
        , ICollection<Review>? reviews
        , ICollection<OpenReferralContact>? contacts
        , ICollection<Cost_Option>? cost_options
        , ICollection<Service_Area>? service_areas
        , ICollection<OpenReferralServiceAtLocation>? service_at_locations
        , ICollection<Service_Taxonomy>? service_taxonomys
        )
    {
        Id = id;
        Name = name;
        Description = description;
        Accreditations = accreditations;
        Assured_date = assured_date;
        Attending_access = attending_access;
        Attending_type = attending_type;
        Deliverable_type = deliverable_type;
        Status = status;
        Url = url;
        Email = email;
        Fees = fees;
        Eligibilitys = eligibilitys;
        Fundings = fundings;
        Holiday_schedules = holiday_schedules;
        Languages = languages;
        Regular_schedules = regular_schedules;
        Reviews = reviews;
        Contacts = contacts;
        Cost_options = cost_options;
        Service_areas = service_areas;
        Service_at_locations = service_at_locations;
        Service_taxonomys = service_taxonomys;
    }

    public string Id { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
    public string? Accreditations { get; init; }
    public DateTime? Assured_date { get; init; }
    public string? Attending_access { get; init; }
    public string? Attending_type { get; init; } 
    public string? Deliverable_type { get; init; } 
    public string? Status { get; init; }
    public string? Url { get; init; }
    public string? Email { get; init; }
    public string? Fees { get; init; }

    public virtual ICollection<EligibilityItem>? Eligibilitys { get; init; }
    public virtual ICollection<Funding>? Fundings { get; init; }
    public virtual ICollection<Holiday_Schedule>? Holiday_schedules { get; init; }
    public virtual ICollection<LanguageItem>? Languages { get; init; }
    public virtual ICollection<Regular_Schedule>? Regular_schedules { get; init; }
    public virtual ICollection<Review>? Reviews { get; init; }
    public virtual ICollection<OpenReferralContact>? Contacts { get; init; }
    public virtual ICollection<Cost_Option>? Cost_options { get; init; }
    public virtual ICollection<Service_Area>? Service_areas { get; init; }
    public virtual ICollection<OpenReferralServiceAtLocation>? Service_at_locations { get; init; }
    public virtual ICollection<Service_Taxonomy>? Service_taxonomys { get; init; }

}
