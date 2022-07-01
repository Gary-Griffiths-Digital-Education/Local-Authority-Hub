using Application.Common.Interfaces;
using LAHub.Domain.Events;
using MediatR;

namespace Application.Commands.CreateContactMechanismType;

public record class CreateContactMechanismTypeCommand : IRequest<Guid>
{
    public CreateContactMechanismTypeCommand(string name, string? description)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; init; }

    public string? Description { get; init; }
}

public class CreateContactMechanismTypeCommandHandler : IRequestHandler<CreateContactMechanismTypeCommand, Guid>
{
    private readonly ILAHubDbContext _context;

    public CreateContactMechanismTypeCommandHandler(ILAHubDbContext context)
    {
        _context = context;
    }
    public async Task<Guid> Handle(CreateContactMechanismTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = new LAHub.Domain.Entities.ContactMechanismType()
        {
            Name = request.Name,
            Description = request.Description
        };

        entity.AddDomainEvent(new ContactMechanismTypeCreatedEvent(entity));

        _context.ContactMechanismTypes.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;

    }
}
