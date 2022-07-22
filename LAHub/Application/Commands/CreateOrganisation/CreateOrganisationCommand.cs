using Application.Common.Interfaces;
using LAHub.Domain.Entities;
using LAHub.Domain.Events;
using MediatR;

namespace Application.Commands.CreateOrganisation;

public class CreateOrganisationCommand : IRequest<Guid>
{
    public CreateOrganisationCommand(
        Tenant? tenant,
        string? name,
        string? description,
        string? logoUrl,
        string? logoAltText,
        OrganisationType? organisationType,
        Contact? contact,
        ICollection<Service>? services
        )
    {
        Name = name;
        Description = description;
        LogoUrl = logoUrl;
        LogoAltText = logoAltText;
        Tenant = tenant;
        OrganisationType = organisationType;
        Contact = contact;
        Services = services;
    }

    public Tenant? Tenant { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? LogoUrl { get; set; }
    public string? LogoAltText { get; set; }
    public OrganisationType? OrganisationType { get; set; }
    public Contact? Contact { get; set; }
    public ICollection<Service>? Services { get; set; }
}

public class GetOrganisationByIdCommandHandler : IRequestHandler<CreateOrganisationCommand, Guid>
{
    private readonly ILAHubDbContext _context;

    public GetOrganisationByIdCommandHandler(ILAHubDbContext context)
    {
        _context = context;
    }
    public async Task<Guid> Handle(CreateOrganisationCommand request, CancellationToken cancellationToken)
    {
#pragma warning disable CS8604 // Possible null reference argument.
        var entity = new LAHub.Domain.Entities.Organisation(
            request.Tenant,
            request.OrganisationType,
            request.Name,
            request.Description,
            request.LogoUrl,
            request.LogoAltText,
            request.Contact);
#pragma warning restore CS8604 // Possible null reference argument.

        if (request.Services != null)
            entity.Services = request.Services;


        entity.AddDomainEvent(new OrganisationCreatedEvent(entity));

        _context.Organisations.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}




