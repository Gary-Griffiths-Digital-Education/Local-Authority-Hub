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
        Tenant tenant,
        string name,
        string? description,
        string? logoUrl,
        string? logoAltText,
        OrganisationType organisationType,
        Contact? contact,
        ICollection<Service> services)
    {
        Id = id;
        Tenant = tenant;
        OrganisationType = organisationType;
        Name = name;
        Description = description;
        LogoUrl = logoUrl;
        LogoAltText = logoAltText;
        Contact = contact;
        if (contact != null)
        {
            ContactId = contact.Id;
        }
        Services = services;
    }

    public Guid Id { get; init; }

    public string Name { get; init; }

    public string? Description { get; init; }

    public Tenant Tenant { get; private set; } = default!;

    public OrganisationType OrganisationType { get; private set; } = default!;

    public string? LogoUrl { get; private set; } = default!;
    public string? LogoAltText { get; private set; } = default!;

    public Guid? ContactId { get; private set; } = default!;

    public Contact? Contact { get; private set; } = default!;

    public ICollection<Service> Services { get; set; }
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

        entity.Id = request.Id;
        entity.Tenant = request.Tenant;
        entity.OrganisationType = request.OrganisationType;
        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.LogoUrl = request.LogoUrl;
        entity.LogoAltText = request.LogoAltText;
        entity.Contact = request.Contact;
        entity.Services = request.Services;

        _context.Organisations.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
