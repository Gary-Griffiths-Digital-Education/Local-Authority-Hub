namespace LAHub.Domain.OpenReferralEnities;

public class OpenReferralReview : BaseEntity<string>
{
    private OpenReferralReview() { }

    
    public OpenReferralReview(string id, string title, string? description, DateTime date, string? score, string? url, string? widget
        //,OpenReferralService service
        )
    {
        Id = id;
        //Service = service;
        Title = title;
        Description = description;
        Date = date;
        Score = score;
        Url = url;
        Widget = widget;
    }

    //public OpenReferralService Service { get; set; } = default!;
    public string Title { get; init; } = default!;
    public string? Description { get; init; }
    public DateTime Date { get; init; }
    public string? Score { get; init; }
    public string? Url { get; init; }
    public string? Widget { get; init; }
    
}
