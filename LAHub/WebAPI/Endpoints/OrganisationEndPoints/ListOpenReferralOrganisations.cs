using Application.Commands.ListOrganisation;
using Ardalis.ApiEndpoints;
using LAHub.Domain.OpenReferralEnities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.OrganisationEndPoints;

public class ListOpenReferralOrganisations : EndpointBaseAsync
    .WithoutRequest
    .WithResult<ActionResult<List<OpenReferralOrganisationRecord>>>
{
    private ISender _mediator = null!;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    [SwaggerOperation(
    Summary = "List of Open Referral Organisations",
    Description = "List of Open Referral Organisations",
    OperationId = "OpenReferralOrganisation.List",
    Tags = new[] { "ListOpenReferralOrganisations" })
    ]
    [HttpGet(ListOpenReferralOrganisationCommand.Route)]
    public override async Task<ActionResult<List<OpenReferralOrganisationRecord>>> HandleAsync(CancellationToken cancellationToken = default)
    {
        
        try
        {
            ListOpenReferralOrganisationCommand request = new ListOpenReferralOrganisationCommand();
            var result = await Mediator.Send(request, cancellationToken);
            return result;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return BadRequest();
        }
    }
}
