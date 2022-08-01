using Application.Commands.UpdateOrganisation;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.OrganisationEndPoints;

public class Update : EndpointBaseAsync
    .WithRequest<UpdateOrganisationCommand>
    .WithResult<ActionResult<Guid>>
{
    private ISender _mediator = null!;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    [SwaggerOperation(
    Summary = "Updates an Organisation",
    Description = "Updates an Organisation with Services",
    OperationId = "Organisation.Update",
    Tags = new[] { "Simple Organisation" })
    ]
    [HttpPut]
    [Route("api/UpdateOrganisation")]
    public override async Task<ActionResult<Guid>> HandleAsync([FromBody] UpdateOrganisationCommand request, CancellationToken cancellationToken = default)
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

