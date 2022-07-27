namespace LAHub.Domain.OpenReferralEnities;

public class OpenReferralPhone : BaseEntity<string>
{
    private OpenReferralPhone() { }
    public OpenReferralPhone(string id, string number)
    {
        Id = id;
        Number = number;
    }

    public string Number { get; init; } = default!;
}
