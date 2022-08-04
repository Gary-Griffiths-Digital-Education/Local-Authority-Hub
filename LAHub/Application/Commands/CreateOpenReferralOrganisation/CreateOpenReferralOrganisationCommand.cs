using Application.Common.Interfaces;
using AutoMapper;
using LAHub.Domain.Events;
using LAHub.Domain.OpenReferralEnities;
using LAHub.Domain.RecordEntities;
using MediatR;

namespace Application.Commands.CreateOpenReferralOrganisation;

public class CreateOpenReferralOrganisationCommand : IRequest<string>
{
    public CreateOpenReferralOrganisationCommand(OpenReferralOrganisationWithServicesRecord openReferralOrganisation)
    {
        OpenReferralOrganisation = openReferralOrganisation;
    }

    public OpenReferralOrganisationWithServicesRecord OpenReferralOrganisation { get; init; }
}

public class CreateOpenReferralOrganisationCommandHandler : IRequestHandler<CreateOpenReferralOrganisationCommand, string>
{
    private readonly ILAHubDbContext _context;
    private readonly IMapper _mapper;

    public CreateOpenReferralOrganisationCommandHandler(ILAHubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<string> Handle(CreateOpenReferralOrganisationCommand request, CancellationToken cancellationToken)
    {
        

        try
        {
            var entity = _mapper.Map<OpenReferralOrganisation>(request.OpenReferralOrganisation);
           
            entity.AddDomainEvent(new OpenReferralOrganisationCreatedEvent(entity));

            _context.OpenReferralOrganisations.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }

        if (request is not null && request.OpenReferralOrganisation is not null) 
            return request.OpenReferralOrganisation.Id;
        else
            return string.Empty;
    }
}
