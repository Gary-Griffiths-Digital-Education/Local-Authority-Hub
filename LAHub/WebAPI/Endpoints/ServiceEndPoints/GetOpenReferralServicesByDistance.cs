using Application.Commands.GetServices;
using Application.Common.Models;
using Ardalis.ApiEndpoints;
using LAHub.Domain.OpenReferralEnities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Services;

public class GetOpenReferralServicesByDistance : EndpointBaseAsync
.WithRequest<GetOpenReferralServicesByDistanceCommand>
.WithResult<ActionResult<PaginatedList<OpenReferralServiceRecord>>>
{
    private ISender _mediator = null!;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    [SwaggerOperation(
    Summary = "Gets services by distance",
    Description = "Gets services by distance",
    //OperationId = "Author.Create",
    Tags = new[] { "Services" })
    ]
    [HttpGet(GetOpenReferralServicesByDistanceCommand.Route)]
    public override async Task<ActionResult<PaginatedList<OpenReferralServiceRecord>>> HandleAsync([FromRoute] GetOpenReferralServicesByDistanceCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
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
