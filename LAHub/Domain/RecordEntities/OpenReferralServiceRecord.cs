namespace LAHub.Domain.OpenReferralEnities;

public record OpenReferralServiceRecord 
{
    private OpenReferralServiceRecord()
    {

    }
    public OpenReferralServiceRecord(string id, string name, string? description, string? accreditations, DateTime? assured_date, string? attending_access, string? attending_type, string? deliverable_type, string? status, string? url, string? email, string? fees)
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

}
