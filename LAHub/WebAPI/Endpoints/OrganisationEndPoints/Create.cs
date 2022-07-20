using Application.Commands.CreateOrganisation;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.OrganisationEndPoints;

public class Create : EndpointBaseAsync
    .WithRequest<CreateOrganisationCommand>
    .WithResult<ActionResult<Guid>>
{
    private ISender _mediator = null!;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    [SwaggerOperation(
    Summary = "Creates an Organisation",
    Description = "Creates an Organisation with Services",
    OperationId = "Organisation.Create",
    Tags = new[] { "CreateOrganisation" })
    ]
    [HttpPost]
    [Route("api/CreateOrganisation")]
    public override async Task<ActionResult<Guid>> HandleAsync([FromBody] CreateOrganisationCommand request, CancellationToken cancellationToken = default)
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
