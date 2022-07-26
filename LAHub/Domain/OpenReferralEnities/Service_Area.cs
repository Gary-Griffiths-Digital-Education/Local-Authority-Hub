﻿namespace LAHub.Domain.OpenReferralEnities;

public class Service_Area
{
    private Service_Area() { }
    public Service_Area(string id, string service_area, string linkId, string? extent, string? uri)
    {
        Id = id;
        Service_area = service_area;
        LinkId = linkId;
        Extent = extent;
        Uri = uri;
    }

    public string Id { get; init; } = default!;
    public string Service_area { get; init; } = default!;
    public string LinkId { get; init; } = default!;
    public string? Extent { get; init; }   
    public string? Uri { get; init; }
}
