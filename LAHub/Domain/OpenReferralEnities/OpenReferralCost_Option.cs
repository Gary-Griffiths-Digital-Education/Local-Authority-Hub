﻿namespace LAHub.Domain.OpenReferralEnities;

public class OpenReferralCost_Option : BaseEntity<string>
{
    private OpenReferralCost_Option() { }
    public OpenReferralCost_Option(string id, string amount_description, int amount, string? linkId, string? option, DateTime? valid_from
        , DateTime? valid_to
        )
    {
        Id = id;
        Amount_description = amount_description;
        Amount = amount;
        LinkId = linkId;
        Option = option;
        Valid_from = valid_from;
        Valid_to = valid_to;
    }
    public string Amount_description { get; init; } = default!;
    public int Amount { get; init; }
    public string? LinkId { get; init; }
    public string? Option { get; init; }
    public DateTime? Valid_from { get; init; }
    public DateTime? Valid_to { get; init; }
}