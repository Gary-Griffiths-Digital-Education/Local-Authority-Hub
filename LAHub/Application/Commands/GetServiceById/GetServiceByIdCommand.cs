using Application.Common.Exceptions;
using Application.Common.Interfaces;
using LAHub.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.GetServiceById;

public class GetServiceByIdCommand : IRequest<Service>
{
    public GetServiceByIdCommand(Guid id)
    {
        Id = id;
    }

    public const string Route = "api/GetServiceByIdDepricated/{ServiceId:Guid}";
    public static string BuildRoute(Guid srvId) => Route.Replace("{ServiceId:Guid}", srvId.ToString());

    public Guid Id { get; set; }
}

public class GetServiceByIdCommandHandler : IRequestHandler<GetServiceByIdCommand, Service>
{
    private readonly ILAHubDbContext _context;

    public GetServiceByIdCommandHandler(ILAHubDbContext context)
    {
        _context = context;
    }

    public async Task<Service> Handle(GetServiceByIdCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Services
            .Include(x => x.Organisation)
            .Include(x => x.ServiceClassifications)
            .ThenInclude(x => x.Classification)
            .Include(x => x.Contact)
            .Include(x => x.Location)
            .ThenInclude(x => (x != null) ? x.Address : null)
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken: cancellationToken);

        //var entity = await _context.Services
        //.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Service), request.Id);
        }

        //Need to remove self referencing items


        if (entity.Organisation != null)
            entity.Organisation.Services = null!;

//        foreach (var item in entity.ServiceLocations)
//        {
//#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
//            item.Service = null;
//#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
//        }
         

        return entity;
    }
}

