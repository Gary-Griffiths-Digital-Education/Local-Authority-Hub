using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using LAHub.Domain.OpenReferralEnities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.GetOpenReferralOrganisationById;


public class GetOpenReferralOrganisationByIdCommand : IRequest<OpenReferralOrganisationWithServicesRecord>
{
    public string Id { get; set; } = default!;
}

public class GetOpenReferralOrganisationByIdHandler : IRequestHandler<GetOpenReferralOrganisationByIdCommand, OpenReferralOrganisationWithServicesRecord>
{
    private readonly ILAHubDbContext _context;
    private readonly IMapper _mapper;

    public GetOpenReferralOrganisationByIdHandler(ILAHubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<OpenReferralOrganisationWithServicesRecord> Handle(GetOpenReferralOrganisationByIdCommand request, CancellationToken cancellationToken)
    {
        //var entity = await _context.Organisations
        //.FindAsync(new object[] { request.Id }, cancellationToken);

        var entity = await _context.OpenReferralOrganisations
           .Include(x => x.Services)
           .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken: cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(OpenReferralOrganisation), request.Id);
        }

        //var services = await _context.Services
        //    .Include(x => x.Organisation)
        //    .Include(x => x.ServiceClassifications)
        //    .ThenInclude(x => x.Classification)
        //    .Include(x => x.Contact)
        //    .Include(x => x.Location)
        //    .ThenInclude(x => (x != null) ? x.Address : null)
        //    .Where(p => p.Id == entity.Id).ToListAsync(cancellationToken: cancellationToken);

        //entity.Services = services;
        
        List<OpenReferralServiceRecord> openReferralServices = new();
        if (entity.Services != null)
        {
            foreach (OpenReferralService openReferralService in entity.Services)
            {
                openReferralServices.Add(new OpenReferralServiceRecord(
                    openReferralService.Id,
                    openReferralService.Name,
                    openReferralService.Description,
                    openReferralService.Accreditations,
                    openReferralService.Assured_date,
                    openReferralService.Attending_access,
                    openReferralService.Attending_type,
                    openReferralService.Deliverable_type,
                    openReferralService.Status,
                    openReferralService.Url,
                    openReferralService.Email,
                    openReferralService.Fees
                    ));
            }
        }


        var result = new OpenReferralOrganisationWithServicesRecord(
            entity.Id,
            entity.Name,
            entity.Description,
            entity.Logo,
            entity.Uri,
            entity.Url,
            openReferralServices);

        return result;
    }
}


