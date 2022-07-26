namespace LAHub.Domain.OpenReferralEnities;

public class Holiday_Schedule
{
    private Holiday_Schedule() { }
    public Holiday_Schedule(string id, bool closed, DateTime? closes_at, DateTime? start_date, DateTime? end_date, DateTime? opens_at
        //OpenReferralServiceAtLocation? service_at_location
        )
    {
        Id = id;
        Closed = closed;
        Closes_at = closes_at;
        Start_date = start_date;
        End_date = end_date;
        Opens_at = opens_at;
        //Service_at_location = service_at_location;
    }

    public string Id { get; init; } = default!;
    public bool Closed { get; init; }
    public DateTime? Closes_at { get; init; }
    public DateTime? Start_date { get; init; }
    public DateTime? End_date { get; init; }
    public DateTime? Opens_at { get; init; }
    //public OpenReferralServiceAtLocation? Service_at_location { get; init; }
}
