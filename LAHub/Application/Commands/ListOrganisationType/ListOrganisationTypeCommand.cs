using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.ListOrganisationType;

public record OrganisationTypeRecord(Guid Id, string Name, string? Description);
public class ListOrganisationTypeCommand : IRequest<List<OrganisationTypeRecord>>
{
}

public class ListOrganisationTypeCommandHandler : IRequestHandler<ListOrganisationTypeCommand, List<OrganisationTypeRecord>>
{
    private readonly ILAHubDbContext _context;

    public ListOrganisationTypeCommandHandler(ILAHubDbContext context)
    {
        _context = context;
    }
    public async Task<List<OrganisationTypeRecord>> Handle(ListOrganisationTypeCommand request, CancellationToken cancellationToken)
    {
        var OrganisationTypes = await _context.OrganisationTypes.Select(org => new OrganisationTypeRecord(org.Id, org.Name, org.Description)).ToListAsync();
        return OrganisationTypes;
    }
}
