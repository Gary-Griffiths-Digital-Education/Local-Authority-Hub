using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Models;
using AutoMapper;
using LAHub.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.GetServices;

public class GetServicesByDistanceCommand : IRequest<PaginatedList<ServiceItem>>
{
    public GetServicesByDistanceCommand(double latitude, double longtitude, double meters, int pageNumber = 1, int pageSize = 10)
    {
        Latitude = latitude;
        Longtitude = longtitude;
        Meters = meters;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    public double Latitude { get; init; }
    public double Longtitude { get; init; }
    public double Meters { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetServicesByDistanceCommandHandler : IRequestHandler<GetServicesByDistanceCommand, PaginatedList<ServiceItem>>
{
    private readonly ILAHubDbContext _context;
    private readonly IMapper _mapper;

    public GetServicesByDistanceCommandHandler(ILAHubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<PaginatedList<ServiceItem>> Handle(GetServicesByDistanceCommand request, CancellationToken cancellationToken)
    {
        return await Task.Run(() => GetServicesByDistance(request, cancellationToken), cancellationToken);
    }

    private PaginatedList<ServiceItem> GetServicesByDistance(GetServicesByDistanceCommand request, CancellationToken token)
    {
        //var currentLocation = Helper.CreatePoint(request.Latitude, request.Longtitude);
        //var srv = _context.Services.ToList();

        var entities = _context.Services
           .Include(x => x.Location);

        //var services =
        //    from serv in _context.Services
        //    join loc in _context.Locations on serv.LocationId equals loc.Id
        //    //where Helper.GetDistance(request.Latitude, request.Longtitude, loc.Latitude, loc.Longitude, serv.Name) < request.Meters
        //    //where loc.LocationPoint.Distance(currentLocation) < request.Meters
        //    //orderby loc.LocationPoint.Distance(currentLocation)
        //    select serv;

        //var services =
        //    from serv in _context.Services
        //    join loc in _context.Locations on serv.LocationId equals loc.Id
        //    //where loc.LocationPoint.Distance(currentLocation) < request.Meters
        //    //orderby loc.LocationPoint.Distance(currentLocation)
        //    select serv;

        var lst = entities.ToList();

        var servicesAtDistance = lst.Where(x => Helper.GetDistance(request.Latitude, request.Longtitude, x?.Location?.Latitude, x?.Location?.Longitude, x?.Name) < request.Meters);
        //var servicesAtDistance = from serv in lst
        //                         where Helper.GetDistance(request.Latitude, request.Longtitude, serv.Location.Latitude, serv.Location.Longitude, serv.Name) < request.Meters
        //                         select serv;


        var r1 = _mapper.Map<List<ServiceItem>>(servicesAtDistance);
        var paglst = r1.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
        var result = new PaginatedList<ServiceItem>(paglst, paglst.Count, request.PageNumber, request.PageSize);

        //var result = await r1.AsQueryable().PaginatedListAsync(request.PageNumber, request.PageSize); 

        //lst = lst.Where(x => )
        //where Helper.GetDistance(request.Latitude, request.Longtitude, loc.Latitude, loc.Longitude, serv.Name) < request.Meters

        //var result = await services.ProjectTo<ServiceItem>(_mapper.ConfigurationProvider)
        //    .PaginatedListAsync(request.PageNumber, request.PageSize);

        //throw new NotImplementedException();
        return result;
    }
}
