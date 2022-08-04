using Application.Common.Exceptions;
using Application.Common.Interfaces;
using LAHub.Domain.Events;
using LAHub.Domain.OpenReferralEnities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.GetOpenReferralOrganisationById;


public class UpdateOpenReferralOrganisationCommand : IRequest<string>
{
    public UpdateOpenReferralOrganisationCommand(string id, OpenReferralOrganisation openReferralOrganisation)
    {
        Id = id;
        OpenReferralOrganisation = openReferralOrganisation;
    }

    public OpenReferralOrganisation OpenReferralOrganisation { get; init; }

    public string Id { get; set; } = default!;
}

public class UpdateOpenReferralOrganisationCommandHandler : IRequestHandler<UpdateOpenReferralOrganisationCommand, string>
{
    private readonly ILAHubDbContext _context;

    public UpdateOpenReferralOrganisationCommandHandler(ILAHubDbContext context)
    {
        _context = context;
    }

    public async Task<string> Handle(UpdateOpenReferralOrganisationCommand request, CancellationToken cancellationToken)
    {
        if (request == null || request.OpenReferralOrganisation == null)
            return string.Empty;

        var entity = await _context.OpenReferralOrganisations
          .Include(x => x.Services)
          .SingleOrDefaultAsync(p => p.Id == request.Id, cancellationToken: cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(OpenReferralOrganisation), request.Id);
        }

        try
        {

            entity.Update(request.OpenReferralOrganisation);

            if (entity.Services != null && request.OpenReferralOrganisation.Services != null)
            {
                // Delete children (does this need to be a soft delete)
                foreach (var existingChild in entity.Services)
                {
                    if (!request.OpenReferralOrganisation.Services.Any(c => c.Id == existingChild.Id))
                    {
                        // Replace with soft delete
                        //_context.OpenReferralServices.Remove(existingChild);
                    }

                }

                // Update and Insert children
                foreach (var childModel in request.OpenReferralOrganisation.Services)
                {
                    var existingChild = entity.Services
                        .Where(c => c.Id == childModel.Id && c.Id != default(string))
                        .SingleOrDefault();

                    if (existingChild != null)
                        existingChild.Update(childModel);
                    else
                    {
                        entity.AddDomainEvent(new OpenReferralServiceCreatedEvent(childModel));

                        _context.OpenReferralServices.Add(childModel);

                    }
                }
            }

            if (entity.Reviews != null && request.OpenReferralOrganisation.Reviews != null)
            {
                // Delete children (does this need to be a soft delete)
                foreach (var existingChild in entity.Reviews)
                {
                    if (!request.OpenReferralOrganisation.Reviews.Any(c => c.Id == existingChild.Id))
                        _context.OpenReferralReviews.Remove(existingChild);
                }

                foreach (var childModel in request.OpenReferralOrganisation.Reviews)
                {
                    var existingChild = entity.Reviews
                        .Where(c => c.Id == childModel.Id && c.Id != default(string))
                        .SingleOrDefault();

                    if (existingChild != null)
                        existingChild.Update(childModel);
                    else
                    {
                        entity.AddDomainEvent(new OpenReferralReviewCreatedEvent(childModel));

                        _context.OpenReferralReviews.Add(childModel);

                    }
                }
            }

            await _context.SaveChangesAsync(cancellationToken);
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }

        return entity.Id;
    }
}


