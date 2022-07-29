using Application.Common.Exceptions;
using Application.Common.Interfaces;
using LAHub.Domain.Entities;
using LAHub.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.UpdateOrganisation;

public record class UpdateOrganisationCommand : IRequest<Guid>
{
    public UpdateOrganisationCommand(
        Guid id,
        Guid? tenantId,
        string? name,
        string? description,
        string? logoUrl,
        string? logoAltText,
        Guid? organisationTypeId,
        Guid? contactId,
        string? contactName,
        string? contactEmail,
        ICollection<Service>? services)
    {
        Id = id;
        TenantId = tenantId;
        OrganisationTypeId = organisationTypeId;
        Name = name;
        Description = description;
        LogoUrl = logoUrl;
        LogoAltText = logoAltText;
        ContactId = contactId;
        ContactName = contactName;
        ContactEmail = contactEmail;
        Services = services;
    }

    public Guid Id { get; set; }
    public Guid? TenantId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? LogoUrl { get; set; }
    public string? LogoAltText { get; set; }
    public Guid? OrganisationTypeId { get; set; }
    public Guid? ContactId { get; set; }
    public string? ContactName { get; set; }
    public string? ContactEmail { get; set; }
    public ICollection<Service>? Services { get; set; }
}

public class UpdateOrganisationCommandHandler : IRequestHandler<UpdateOrganisationCommand, Guid>
{
    private readonly ILAHubDbContext _context;

    public UpdateOrganisationCommandHandler(ILAHubDbContext context)
    {
        _context = context;
    }
    public async Task<Guid> Handle(UpdateOrganisationCommand request, CancellationToken cancellationToken)
    {
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

        var tenant = _context.Tenants.FirstOrDefault(x => x.Id == request.TenantId);
        var organisationType = _context.OrganisationTypes.FirstOrDefault(x => x.Id == request.OrganisationTypeId);
        var contact = _context.Contacts.FirstOrDefault(x => x.Id == request.ContactId);
        if (contact != null)
        {
            if(request.ContactName != null)
                contact.Name = request.ContactName;
            contact.Email = request.ContactEmail;
        }
        else
        {
            contact = new Contact(tenant, (request.ContactName != null) ? request.ContactName : string.Empty,
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
        }
        


        entity.Id = request.Id;
        if (tenant != null)
            entity.Tenant = tenant;
        if (organisationType != null)
            entity.OrganisationType = organisationType;
#pragma warning disable CS8601 // Possible null reference assignment.        
        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.LogoUrl = request.LogoUrl;
        entity.LogoAltText = request.LogoAltText;
#pragma warning restore CS8601 // Possible null reference assignment.        
        entity.Contact = contact;

        //ToDo
        //if (request.Services != null && request.Services.Any())
        //    entity.Services = request.Services;


        try
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }

        return entity.Id;
    }
}
