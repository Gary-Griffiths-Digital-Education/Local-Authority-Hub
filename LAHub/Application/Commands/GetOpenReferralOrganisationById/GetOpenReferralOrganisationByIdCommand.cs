using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using LAHub.Domain.OpenReferralEnities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.GetOpenReferralOrganisationById;


public class GetOpenReferralOrganisationByIdCommand : IRequest<OpenReferralOrganisationRecord>
{
    public const string Route = "/organizations/{id}";
    public static string BuildRoute(string orgId) => Route.Replace("{id:string}", orgId.ToString());

    public string Id { get; set; } = default!;
}

public class GetOpenReferralOrganisationByIdHandler : IRequestHandler<GetOpenReferralOrganisationByIdCommand, OpenReferralOrganisationRecord>
{
    private readonly ILAHubDbContext _context;
    private readonly IMapper _mapper;

    public GetOpenReferralOrganisationByIdHandler(ILAHubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<OpenReferralOrganisationRecord> Handle(GetOpenReferralOrganisationByIdCommand request, CancellationToken cancellationToken)
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
                //{
                //Id = openReferralService.Id,
                //    Name = openReferralService.Name,
                //    Accreditations = openReferralService.Accreditations,
                //    Assured_date = openReferralService.Assured_date,
                //    Attending_access = openReferralService.Attending_access,
                //    Attending_type = openReferralService.Attending_type,
                //    Deliverable_type = openReferralService.Deliverable_type,
                //    Description = openReferralService.Description,
                //    Email = openReferralService.Email,
                //    Fees = openReferralService.Fees,
                //    Status = openReferralService.Status,
                //    Url = openReferralService.Url,
                //});
            }
        }


        var result = new OpenReferralOrganisationRecord(
            entity.Id,
            entity.Name,
            entity.Description,
            entity.Logo,
            entity.Uri,
            entity.Url,
            openReferralServices);
        //{
        //    Id = entity.Id,
        //    Name = entity.Name,
        //    Description = entity.Description,
        //    Logo = entity.Logo,
        //    Uri = entity.Uri,
        //    Url = entity.Url,
        //    Services = openReferralServices
        //};
        

        return result;
    }
}


