using Application.Common.Exceptions;
using Application.Common.Interfaces;
using LAHub.Domain.Entities;
using MediatR;

namespace Application.Commands.CreateContactMechanismType;
/*
public record class UpdateContactMechanismTypeCommand : IRequest<Guid>
{
    public UpdateContactMechanismTypeCommand(Guid id, string name, string? description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
    public Guid Id { get; init; }
    public string Name { get; init; }

    public string? Description { get; init; }
}

public class UpdateContactMechanismTypeCommandHandler : IRequestHandler<UpdateContactMechanismTypeCommand, Guid>
{
    private readonly ILAHubDbContext _context;

    public UpdateContactMechanismTypeCommandHandler(ILAHubDbContext context)
    {
        _context = context;
    }
    public async Task<Guid> Handle(UpdateContactMechanismTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ContactMechanismTypes
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ContactMechanismType), request.Id);
        }

        entity.Name = request.Name;
        entity.Description = request.Description;

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;

    }
}
*/