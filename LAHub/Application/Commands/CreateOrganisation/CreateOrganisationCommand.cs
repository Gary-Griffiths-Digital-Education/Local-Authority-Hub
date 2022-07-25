using Application.Common.Interfaces;
using LAHub.Domain.Entities;
using LAHub.Domain.Events;
using MediatR;

namespace Application.Commands.CreateOrganisation;

public class CreateOrganisationCommand : IRequest<Guid>
{
    public CreateOrganisationCommand(
        Guid? tenantId,
        string? name,
        string? description,
        string? logoUrl,
        string? logoAltText,
        Guid? organisationTypeId,
        string? contactName,
        string? contactEmail,
        ICollection<Service>? services
        )
    {
        Name = name;
        Description = description;
        LogoUrl = logoUrl;
        LogoAltText = logoAltText;
        TenantId = tenantId;
        OrganisationTypeId = organisationTypeId;
        ContactName = contactName;
        ContactEmail = contactEmail;
        Services = services;
    }

    public Guid? TenantId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? LogoUrl { get; set; }
    public string? LogoAltText { get; set; }
    public Guid? OrganisationTypeId { get; set; }
    public string? ContactName { get; set; }
    public string? ContactEmail { get; set; }
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
        var tenant = _context.Tenants.FirstOrDefault(x => x.Id == request.TenantId);
        var organisationType = _context.OrganisationTypes.FirstOrDefault(x => x.Id == request.OrganisationTypeId);

        Contact contact = new Contact(tenant, request.ContactName,
                            null,
                            null,
                            null,
                            null,
                            request.ContactEmail,
                            null,
                            null,
                            null,
                            null,
                            null,
                            null,
                            null,
                            null,
                            null,
                            null);

        var entity = new LAHub.Domain.Entities.Organisation(
            tenant,
            organisationType,
            request.Name,
            request.Description,
            request.LogoUrl,
            request.LogoAltText,
            contact);
#pragma warning restore CS8604 // Possible null reference argument.

        try
        {
            //ToDo
            //if (request.Services != null && request.Services.Any())
            //    entity.Services = request.Services;

            entity.AddDomainEvent(new OrganisationCreatedEvent(entity));

            _context.Organisations.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        


        

        return entity.Id;
        
    }
}




