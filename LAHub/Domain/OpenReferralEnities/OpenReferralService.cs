namespace LAHub.Domain.OpenReferralEnities;

public class OpenReferralService : BaseEntity<string>
{
    private OpenReferralService() { }

    public OpenReferralService(string id, string name, string? description, string? accreditations, DateTime? assured_date, string? attending_access, string? attending_type, string? deliverable_type, string? status, string? url, string? email, string? fees
        , ICollection<OpenReferralEligibility>? eligibilitys, ICollection<OpenReferralFunding>? fundings
        , ICollection<OpenReferralHoliday_Schedule>? holiday_schedules
        , ICollection<OpenReferralLanguage>? languages
        , ICollection<OpenReferralRegular_Schedule>? regular_schedules
        , ICollection<OpenReferralReview>? reviews
        , ICollection<OpenReferralContact>? contacts
        , ICollection<OpenReferralCost_Option>? cost_options
        , ICollection<OpenReferralService_Area>? service_areas
        , ICollection<OpenReferralServiceAtLocation>? service_at_locations
        , ICollection<OpenReferralService_Taxonomy>? service_taxonomys
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

    public virtual ICollection<OpenReferralEligibility>? Eligibilitys { get; init; }
    public virtual ICollection<OpenReferralFunding>? Fundings { get; init; }
    public virtual ICollection<OpenReferralHoliday_Schedule>? Holiday_schedules { get; init; }
    public virtual ICollection<OpenReferralLanguage>? Languages { get; init; }
    public virtual ICollection<OpenReferralRegular_Schedule>? Regular_schedules { get; init; }
    public virtual ICollection<OpenReferralReview>? Reviews { get; init; }
    public virtual ICollection<OpenReferralContact>? Contacts { get; init; }
    public virtual ICollection<OpenReferralCost_Option>? Cost_options { get; init; }
    public virtual ICollection<OpenReferralService_Area>? Service_areas { get; init; }
    public virtual ICollection<OpenReferralServiceAtLocation>? Service_at_locations { get; init; }
    public virtual ICollection<OpenReferralService_Taxonomy>? Service_taxonomys { get; init; }

}
