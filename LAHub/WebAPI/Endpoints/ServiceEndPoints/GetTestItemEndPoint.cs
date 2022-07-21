using Application.Commands.GetServices;
using Application.Commands.TestCommand;
using Application.Common.Models;
using Application.Models;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// https://github.com/ardalis/ApiEndpoints#2-introducing-aspnet-core-api-endpoints

namespace WebAPI.Endpoints.Services;

public class GetTestItemEndPoint : EndpointBaseAsync
    .WithRequest<TestCommand>
    .WithResult<ActionResult<PaginatedList<TestItem>>>
{
    private ISender _mediator = null!;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    [SwaggerOperation(
    Summary = "Test Command",
    Description = "Test Command",
    //OperationId = "Author.Create",
    Tags = new[] { "GetTestCommand" })
    ]
    [HttpPost]
    [Route("api/GetTestCommand")]
    public override async Task<ActionResult<PaginatedList<TestItem>>> HandleAsync([FromBody] TestCommand request, CancellationToken cancellationToken = default)
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