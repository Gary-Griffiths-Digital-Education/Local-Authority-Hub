namespace LAHub.Domain.OpenReferralEnities;

public class OpenReferralPhone
{
    private OpenReferralPhone() { }
    public OpenReferralPhone(string id, string number)
    {
        Id = id;
        Number = number;
    }

    public string Id { get; init; } = default!;
    public string Number { get; init; } = default!;
}
