using Application.Common.Interfaces;
using LAHub.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.ListOrganisation;

public record OrganisationRecord(Guid Id, string Name, string? Description);

public class ListOrganisationCommand : IRequest<List<OrganisationRecord>>
{
    public ListOrganisationCommand(Guid tenantId, Guid? organisationTypeId)
    {
        TenantId = tenantId;
        OrganisationTypeId = organisationTypeId;
    }

    public const string Route = "api/ListOrganisationsDepricated/{TenantId:Guid}/{OrganisationTypeId:Guid}";
    public static string BuildRoute(Guid tenantId, Guid? orgTypeId)
    {
        string route = Route.Replace("{TenantId:Guid}", tenantId.ToString());
        route = route.Replace("{OrganisationTypeId:Guid}", orgTypeId.ToString());
        return route;
    }
    

    public Guid TenantId { get; private set; } = default!;

    public Guid? OrganisationTypeId { get; private set; } = default!;
}

public class ListOrganisationCommandHandler : IRequestHandler<ListOrganisationCommand, List<OrganisationRecord>>
{
    private readonly ILAHubDbContext _context;

    public ListOrganisationCommandHandler(ILAHubDbContext context)
    {
        _context = context;
    }

    public async Task<List<OrganisationRecord>> Handle(ListOrganisationCommand request, CancellationToken cancellationToken)
    {
        var lst = _context.Organisations.Where(x => x.Tenant.Id == request.TenantId);
        Guid? organisationTypeId = request.OrganisationTypeId;
        if (request.OrganisationTypeId == Guid.Empty)
            organisationTypeId = null;
        if (organisationTypeId != null)
        {
            lst = lst.Where(x => x.OrganisationType.Id == request.OrganisationTypeId);
        }
        var organisations = await lst.Select(org => new OrganisationRecord(org.Id, org.Name, org.Description)).ToListAsync();
        return organisations;
    }
}
