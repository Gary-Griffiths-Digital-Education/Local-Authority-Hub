using Application.Commands.GetOrganisationById;
using Ardalis.ApiEndpoints;
using LAHub.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.OrganisationEndPoints;

public class GetOrganisationByIdEndPoint : EndpointBaseAsync
.WithRequest<GetOrganisationByIdCommand>
.WithResult<ActionResult<Organisation>>
{
    private ISender _mediator = null!;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    [SwaggerOperation(
    Summary = "Gets a Organisation by id",
    Description = "Gets the required Organisation by id",
    //OperationId = "Author.Create",
    Tags = new[] { "Simple Organisation" })
    ]
    [HttpGet(GetOrganisationByIdCommand.Route)]
    public override async Task<ActionResult<Organisation>> HandleAsync([FromBody] GetOrganisationByIdCommand request, CancellationToken cancellationToken = default)
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

