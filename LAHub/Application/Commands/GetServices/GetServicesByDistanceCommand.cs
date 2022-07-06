using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Application.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LAHub.Domain;
using LAHub.Domain.Entities;
using MediatR;

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
        //var currentLocation = Helper.CreatePoint(request.Latitude, request.Longtitude);
        
        var services =
            from serv in _context.Services
            join servloc in _context.ServiceLocations on serv.Id equals servloc.ServiceId
            join loc in _context.Locations on servloc.LocationId equals loc.Id
            where Helper.GetDistance(request.Latitude, request.Longtitude, loc.Latitude, loc.Longitude) < request.Meters
            //where loc.LocationPoint.Distance(currentLocation) < request.Meters
            //orderby loc.LocationPoint.Distance(currentLocation)
            select serv;

        var lst = services.ToList();

        var result = await services.ProjectTo<ServiceItem>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
        

        //throw new NotImplementedException();
        return result;
    }
}
