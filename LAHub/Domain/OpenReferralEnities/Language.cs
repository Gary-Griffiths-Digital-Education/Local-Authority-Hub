namespace LAHub.Domain.OpenReferralEnities;

public class LanguageItem
{
    private LanguageItem() { }
    public LanguageItem(string id, string language)
    {
        Id = id;
        Language = language;
    }

    public string Id { get; init; } = default!;
    public string Language { get; init; } = default!;
}
