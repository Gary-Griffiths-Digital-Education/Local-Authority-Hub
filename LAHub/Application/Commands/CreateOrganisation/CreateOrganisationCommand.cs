﻿using Application.Common.Interfaces;
using LAHub.Domain.Entities;
using LAHub.Domain.Events;
using MediatR;

namespace Application.Commands.CreateOrganisation;

public record class CreateOrganisationCommand : IRequest<Guid>
{
    public CreateOrganisationCommand(Tenant tenant,
        string name,
        string? description,
        string? logoUrl,
        string? logoAltText,
        OrganisationType organisationType,
        Contact? contact,
        ICollection<Service> services)
    {
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

public class CreateOrganisationCommandHandler : IRequestHandler<CreateOrganisationCommand, Guid>
{
    private readonly ILAHubDbContext _context;

    public CreateOrganisationCommandHandler(ILAHubDbContext context)
    {
        _context = context;
    }
    public async Task<Guid> Handle(CreateOrganisationCommand request, CancellationToken cancellationToken)
    {
        var entity = new LAHub.Domain.Entities.Organisation(
            request.Tenant,
            request.OrganisationType,
            request.Name,
            request.Description,
            request.LogoUrl,
            request.LogoAltText,
            request.Contact);

        entity.Services = request.Services;
        

        entity.AddDomainEvent(new OrganisationCreatedEvent(entity));

        _context.Organisations.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
