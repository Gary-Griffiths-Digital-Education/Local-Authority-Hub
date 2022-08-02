using Application.Common.Interfaces;
using Application.Common.Models;
using LAHub.Domain;
using LAHub.Domain.OpenReferralEnities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.GetServices;

public class GetOpenReferralServicesCommand : IRequest<PaginatedList<OpenReferralServiceRecord>>
{
    public GetOpenReferralServicesCommand() { }
    public GetOpenReferralServicesCommand(int? minimum_age, int? maximum_age, double? latitude, double? longtitude, double? proximity, int? pageNumber, int? pageSize, string? text)
    {
        MaximumAge = maximum_age;
        MinimumAge = minimum_age;
        Latitude = latitude;
        Longtitude = longtitude;
        Meters = proximity;
        PageNumber = (pageNumber != null) ? pageNumber.Value : 1;
        PageSize = (pageSize != null) ? pageSize.Value : 1;
        Text = text;
    }

    public int? MaximumAge { get; set; }
    public int? MinimumAge { get; set; }
    public double? Latitude { get; set; }
    public double? Longtitude { get; set; }
    public double? Meters { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? Text { get; set; }   
   
}

public class GetOpenReferralServicesCommandHandler : IRequestHandler<GetOpenReferralServicesCommand, PaginatedList<OpenReferralServiceRecord>>
{
    private readonly ILAHubDbContext _context;

    public GetOpenReferralServicesCommandHandler(ILAHubDbContext context)
    {
        _context = context;
    }
    public async Task<PaginatedList<OpenReferralServiceRecord>> Handle(GetOpenReferralServicesCommand request, CancellationToken cancellationToken)
    {
        var entities = await _context.OpenReferralServices
           .Include(x => x.Eligibilitys)
           .Include(x => x.Service_at_locations)  
           .ThenInclude(x => x.Location).ToListAsync();

        IEnumerable<OpenReferralService> dbservices = default!;
        if (request?.Latitude != null && request?.Longtitude != null && request?.Meters != null)
            dbservices = entities.Where(x => Helper.GetDistance(request.Latitude, request.Longtitude, x?.Service_at_locations?.FirstOrDefault()?.Location.Latitude, x?.Service_at_locations?.FirstOrDefault()?.Location.Longitude, x?.Name) < request.Meters);

        if (request?.MaximumAge != null)
            dbservices = dbservices.Where(x => x.Eligibilitys.Any(x => x.Maximum_age <= request.MaximumAge.Value));

        if (request?.MinimumAge != null)
            dbservices = dbservices.Where(x => x.Eligibilitys.Any(x => x.Minimum_age <= request.MinimumAge.Value));

        if (request?.Text != null)
        {
            dbservices = dbservices.Where(x => x.Name.Contains(request.Text) || (x.Description != null && x.Description.Contains(request.Text)));
        }

        if (dbservices == null)
        {
            dbservices = new List<OpenReferralService>();
        }

        var filteredServices = dbservices.Select(x => new OpenReferralServiceRecord(
            x.Id,       
            x.Name,
            x.Description,
            x.Accreditations,
            x.Assured_date,
            x.Attending_access,
            x.Attending_type,
            x.Deliverable_type,
            x.Status,
            x.Url,
            x.Email,
            x.Fees
            )).ToList();

        if (request != null)
        {
            var pagelist = filteredServices.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
            var result = new PaginatedList<OpenReferralServiceRecord>(filteredServices, pagelist.Count, request.PageNumber, request.PageSize);
            return result;
        }

        return new PaginatedList<OpenReferralServiceRecord>(filteredServices, filteredServices.Count, 1, 10);

    }

}
