namespace LAHub.Domain.OpenReferralEnities;

public class Phone
{
    private Phone() { }
    public Phone(string id, string number)
    {
        Id = id;
        Number = number;
    }

    public string Id { get; init; } = default!;
    public string Number { get; init; } = default!;
}
