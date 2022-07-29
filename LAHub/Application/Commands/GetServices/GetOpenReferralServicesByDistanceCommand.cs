using Application.Common.Interfaces;
using Application.Common.Models;
using LAHub.Domain;
using LAHub.Domain.OpenReferralEnities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Application.Commands.GetServices;

public class GetOpenReferralServicesByDistanceCommand : IRequest<PaginatedList<OpenReferralServiceRecord>>
{
    public GetOpenReferralServicesByDistanceCommand() { }
    public GetOpenReferralServicesByDistanceCommand(double latitude, double longtitude, double meters, int pageNumber = 1, int pageSize = 10)
    {
        Latitude = latitude;
        Longtitude = longtitude;
        Meters = meters;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    public double Latitude { get; set; }
    public double Longtitude { get; set; }
    public double Meters { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;

    public const string Route = "api/ServicesByDistance/{Latitude:double}/{Longtitude:double}/{Meters:double}/{PageNumber:int}/{PageSize:int}";
    public static string BuildRoute(double latitude, double longtitude, double meters, int pageNumber = 1, int pageSize = 10)
    {
        string urlRoute = Route.Replace("{Latitude:double}", latitude.ToString());
        urlRoute = urlRoute.Replace("{Longtitude:double}", longtitude.ToString());
        urlRoute = urlRoute.Replace("{Meters:double}", meters.ToString());
        urlRoute = urlRoute.Replace("{PageNumber:int}", pageNumber.ToString());
        urlRoute = urlRoute.Replace("{PageSize:int}", pageSize.ToString());
        return urlRoute;
    }
   
}

public class GetOpenReferralServicesByDistanceCommandHandler : IRequestHandler<GetOpenReferralServicesByDistanceCommand, PaginatedList<OpenReferralServiceRecord>>
{
    private readonly ILAHubDbContext _context;

    public GetOpenReferralServicesByDistanceCommandHandler(ILAHubDbContext context)
    {
        _context = context;
    }
    public async Task<PaginatedList<OpenReferralServiceRecord>> Handle(GetOpenReferralServicesByDistanceCommand request, CancellationToken cancellationToken)
    {
        var entities = await _context.OpenReferralServices
           .Include(x => x.Service_at_locations)
           .ThenInclude(x => x.Location).ToListAsync();

        var servicesAtDistance = entities.Where(x => Helper.GetDistance(request.Latitude, request.Longtitude, x?.Service_at_locations?.FirstOrDefault()?.Location.Latitude, x?.Service_at_locations?.FirstOrDefault()?.Location.Longitude, x?.Name) < request.Meters);

        var fileterServices = servicesAtDistance.Select(x => new OpenReferralServiceRecord(
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

        var pagelist = servicesAtDistance.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
        var result = new PaginatedList<OpenReferralServiceRecord>(fileterServices, pagelist.Count, request.PageNumber, request.PageSize);
        return result;
    }

}
