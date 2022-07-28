using Application.Common.Interfaces;
using LAHub.Domain.Events;
using LAHub.Domain.OpenReferralEnities;
using MediatR;

namespace Application.Commands.CreateOpenReferralOrganisation;

public class CreateOpenReferralOrganisationCommand : IRequest<string>
{
    public CreateOpenReferralOrganisationCommand(OpenReferralOrganisation openReferralOrganisation)
    {
        OpenReferralOrganisation = openReferralOrganisation;
    }

    public OpenReferralOrganisation OpenReferralOrganisation { get; init; }
}

public class CreateOpenReferralOrganisationCommandHandler : IRequestHandler<CreateOpenReferralOrganisationCommand, string>
{
    private readonly ILAHubDbContext _context;

    public CreateOpenReferralOrganisationCommandHandler(ILAHubDbContext context)
    {
        _context = context;
    }
    public async Task<string> Handle(CreateOpenReferralOrganisationCommand request, CancellationToken cancellationToken)
    {
        var entity = request.OpenReferralOrganisation;

        try
        {
            entity.AddDomainEvent(new OpenReferralOrganisationCreatedEvent(entity));

            _context.OpenReferralOrganisations.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }

        if (entity is not null) 
            return entity.Id;
        else
            return string.Empty;
    }
}
