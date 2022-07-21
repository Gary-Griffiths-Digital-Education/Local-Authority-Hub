using Application.Commands.GetServices;
using Application.Common.Models;
using Application.Models;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// https://github.com/ardalis/ApiEndpoints#2-introducing-aspnet-core-api-endpoints

namespace WebAPI.Endpoints.Services;

public class GetServicesEndPoint : EndpointBaseAsync
    .WithRequest<GetServicesByDistanceCommand>
    .WithResult<ActionResult<PaginatedList<ServiceItem>>>
{
    private ISender _mediator = null!;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    [SwaggerOperation(
    Summary = "Get a list of service within a certain distance",
    Description = "Get a list of service within a certain distance",
    //OperationId = "Author.Create",
    Tags = new[] { "GetServicesByDistance" })
    ]
    [HttpPost]
    [Route("api/GetServicesByDistance")]
    public override async Task<ActionResult<PaginatedList<ServiceItem>>> HandleAsync([FromBody] GetServicesByDistanceCommand request, CancellationToken cancellationToken = default)
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
