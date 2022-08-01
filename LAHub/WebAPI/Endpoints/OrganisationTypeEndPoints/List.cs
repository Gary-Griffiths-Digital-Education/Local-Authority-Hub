using Application.Commands.ListOrganisationType;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.OrganisationTypeEndPoints;

public class ListOrganisationTypes : EndpointBaseAsync
    .WithoutRequest
    .WithResult<ActionResult<List<OrganisationTypeRecord>>>
{
    private ISender _mediator = null!;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    [SwaggerOperation(
    Summary = "List of OrganisationTypes",
    Description = "List of OrganisationTypes",
    OperationId = "OrganisationType.List",
    Tags = new[] { "Simple Organisation" })
    ]
    [HttpGet]
    [Route("api/ListOrganisationTypesDepricated")]
    public override async Task<ActionResult<List<OrganisationTypeRecord>>> HandleAsync(CancellationToken cancellationToken = new())
    {

        try
        {
            ListOrganisationTypeCommand request = new();
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

