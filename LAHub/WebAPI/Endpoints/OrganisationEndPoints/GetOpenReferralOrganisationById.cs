using Application.Commands.GetOpenReferralOrganisationById;
using Application.Commands.GetOrganisationById;
using Ardalis.ApiEndpoints;
using LAHub.Domain.OpenReferralEnities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.OrganisationEndPoints;

public class GetOpenReferralOrganisationByIdEndPoint : EndpointBaseAsync
.WithRequest<GetOpenReferralOrganisationByIdCommand>
.WithResult<ActionResult<OpenReferralOrganisationWithServicesRecord>>
{
    private ISender _mediator = null!;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    [SwaggerOperation(
    Summary = "Gets a Open Referral Organisation by id",
    Description = "Gets the required Open Referral Organisation by id",
    //OperationId = "Author.Create",
    Tags = new[] { "GetOpenReferralOrganisationsById" })
    ]
    [HttpGet(GetOpenReferralOrganisationByIdCommand.Route)]
    public override async Task<ActionResult<OpenReferralOrganisationWithServicesRecord>> HandleAsync([FromRoute] GetOpenReferralOrganisationByIdCommand request, CancellationToken cancellationToken = default)
    {
        try
        { 
            var result = await Mediator.Send(request, cancellationToken);
            return result;
            //var retVal = Ok(result);
            //return Ok(result);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return BadRequest();
        }

    }
}

