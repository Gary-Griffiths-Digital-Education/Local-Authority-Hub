﻿namespace LAHub.Domain.OpenReferralEnities;

public class Physical_Address
{
    private Physical_Address() { }
    public Physical_Address(string id, string address_1, string? city, string postal_code, string? country, string? state_province)
    {
        Id = id;
        Address_1 = address_1;
        City = city;
        Postal_code = postal_code;
        Country = country;
        State_province = state_province;
    }

    public string Id { get; init; } = default!;
    public string Address_1 { get; init; } = default!;
    public string? City { get; init; }
    public string Postal_code { get; init; } = default!;
    public string? Country { get; init; }
    public string? State_province { get; init; }
}