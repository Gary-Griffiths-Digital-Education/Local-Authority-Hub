using Application.Common.Exceptions;
using Application.Common.Interfaces;
using LAHub.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.GetOrganisationById;

public class GetOrganisationByIdCommand : IRequest<Organisation>
{
    public GetOrganisationByIdCommand(Guid id)
    {
        Id = id;
    }

    public const string Route = "api/GetOrganisationByIdDepricated/{OrganisationId:Guid}";
    public static string BuildRoute(Guid orgId) => Route.Replace("{OrganisationId:Guid}", orgId.ToString());

    public Guid Id { get; set; }
}

public class GetOrganisationByIdCommandHandler : IRequestHandler<GetOrganisationByIdCommand, Organisation>
{
    private readonly ILAHubDbContext _context;

    public GetOrganisationByIdCommandHandler(ILAHubDbContext context)
    {
        _context = context;
    }
    public async Task<Organisation> Handle(GetOrganisationByIdCommand request, CancellationToken cancellationToken)
    {
        //var entity = await _context.Organisations
        //.FindAsync(new object[] { request.Id }, cancellationToken);

        var entity = await _context.Organisations
           .Include(x => x.Tenant)
           .Include(x => x.OrganisationType)
           .Include(x => x.Contact)
           .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken: cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Service), request.Id);
        }

        var services = await _context.Services
            .Include(x => x.Organisation)
            .Include(x => x.ServiceClassifications)
            .ThenInclude(x => x.Classification)
            .Include(x => x.Contact)
            .Include(x => x.Location)
            .ThenInclude(x => (x != null) ? x.Address : null)
            .Where(p => p.Id == entity.Id).ToListAsync(cancellationToken: cancellationToken);

        entity.Services = services;

        return entity;
    }
}


