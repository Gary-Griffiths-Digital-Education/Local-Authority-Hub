//using Application.Common.Exceptions;
//using Application.Common.Interfaces;
//using LAHub.Domain.Entities;
//using LAHub.Domain.Events;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Application.Commands.DeleteContactMechanismType;
/*
public record class DeleteContactMechanismTypeCommand : IRequest<Guid>
{
    public DeleteContactMechanismTypeCommand(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; init; }

}

public class DeleteContactMechanismTypeCommandHandler : IRequestHandler<DeleteContactMechanismTypeCommand, Guid>
{
    private readonly ILAHubDbContext _context;

    public DeleteContactMechanismTypeCommandHandler(ILAHubDbContext context)
    {
        _context = context;
    }
    public async Task<Guid> Handle(DeleteContactMechanismTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ContactMechanismTypes
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ContactMechanismType), request.Id);
        }

        _context.ContactMechanismTypes.Remove(entity);

        entity.AddDomainEvent(new ContactMechanismTypeDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
*/