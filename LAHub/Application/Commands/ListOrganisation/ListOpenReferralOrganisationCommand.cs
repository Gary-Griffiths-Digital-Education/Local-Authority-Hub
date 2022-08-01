using Application.Common.Interfaces;
using LAHub.Domain.OpenReferralEnities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.ListOrganisation;

public class ListOpenReferralOrganisationCommand : IRequest<List<OpenReferralOrganisationRecord>>
{
    public ListOpenReferralOrganisationCommand()
    {
       
    }    
}

public class ListOpenReferralOrganisationCommandHandler : IRequestHandler<ListOpenReferralOrganisationCommand, List<OpenReferralOrganisationRecord>>
{
    private readonly ILAHubDbContext _context;

    public ListOpenReferralOrganisationCommandHandler(ILAHubDbContext context)
    {
        _context = context;
    }

    public async Task<List<OpenReferralOrganisationRecord>> Handle(ListOpenReferralOrganisationCommand request, CancellationToken cancellationToken)
    {
        var organisations = await _context.OpenReferralOrganisations.Select(org => new OpenReferralOrganisationRecord(
            org.Id, 
            org.Name, 
            org.Description,
            org.Logo,
            org.Uri,
            org.Url
            )).ToListAsync();
        return organisations;
    }
}
