using Application.Commands.GetServiceById;
using Ardalis.ApiEndpoints;
using LAHub.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Services;

public class GetServiceById : EndpointBaseAsync
.WithRequest<GetServiceByIdCommand>
.WithResult<ActionResult<Service>>
{
    private ISender _mediator = null!;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    [SwaggerOperation(
    Summary = "Gets a service by id",
    Description = "Gets the required service by id",
    //OperationId = "Author.Create",
    Tags = new[] { "GetServicesById" })
    ]
    [HttpPost]
    [Route("api/GetServiceById")]
    public override async Task<ActionResult<Service>> HandleAsync([FromBody] GetServiceByIdCommand request, CancellationToken cancellationToken = default)
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
