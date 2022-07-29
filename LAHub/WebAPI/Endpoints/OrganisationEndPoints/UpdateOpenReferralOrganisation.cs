using Application.Commands.GetOpenReferralOrganisationById;
using Ardalis.ApiEndpoints;
using LAHub.Domain.OpenReferralEnities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.OrganisationEndPoints;

public class UpdateOpenReferralOrganisationEndPoint : EndpointBaseAsync
    .WithRequest<OpenReferralOrganisation>
    .WithResult<ActionResult<string>>
{

    private ISender _mediator = null!;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    [SwaggerOperation(
    Summary = "Updates a Open Referral Organisation by id",
    Description = "Updates the required Open Referral Organisation by id",
    //OperationId = "Author.Create",
    Tags = new[] { "UpdateOpenReferralOrganisations" })
    ]
    [HttpPut(UpdateOpenReferralOrganisationCommand.Route)]
    public override async Task<ActionResult<string>> HandleAsync([FromBody] OpenReferralOrganisation request, CancellationToken cancellationToken = default)
    {
        try
        {
            if (Request == null || Request.Path == null || Request.Path.Value == null)
                return BadRequest();

            var id = Request.Path.Value.Replace("/organizations/", "");
            UpdateOpenReferralOrganisationCommand command = new(id, request);
            var result = await Mediator.Send(command, cancellationToken);
            return result;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return BadRequest();
        }
    }

}
