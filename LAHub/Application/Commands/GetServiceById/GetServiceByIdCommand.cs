﻿using Application.Common.Exceptions;
using Application.Common.Interfaces;
using LAHub.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.GetServiceById;

public class GetServiceByIdCommand : IRequest<Service>
{
    public GetServiceByIdCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}

public class GetServiceByIdCommandHandler : IRequestHandler<GetServiceByIdCommand, Service>
{
    private readonly ILAHubDbContext _context;

    public GetServiceByIdCommandHandler(ILAHubDbContext context)
    {
        _context = context;
    }

    public async Task<Service> Handle(GetServiceByIdCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Services
            .Include(x => x.Organisation)
            .ThenInclude(x => x.OrganisationContacts)
            .Include(x => x.ServiceLocations)
            .ThenInclude(x => x.Location)
            .ThenInclude(x => x.Address)
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken: cancellationToken);

        //var entity = await _context.Services
        //.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Service), request.Id);
        }

        //Need to remove self referencing items
        entity.Organisation.Services = null!;
        foreach(var item in entity.ServiceLocations)
        {
            item.Service = null;
        }

        return entity;
    }
}

