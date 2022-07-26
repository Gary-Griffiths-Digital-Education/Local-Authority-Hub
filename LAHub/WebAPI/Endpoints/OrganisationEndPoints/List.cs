using Application.Commands.ListOrganisation;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.OrganisationEndPoints;

public class ListOrganisations : EndpointBaseAsync
    .WithRequest<ListOrganisationCommand>
    .WithResult<ActionResult<List<OrganisationRecord>>>
{
    private ISender _mediator = null!;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    [SwaggerOperation(
    Summary = "List of Organisations",
    Description = "List of Organisations",
    OperationId = "Organisation.List",
    Tags = new[] { "ListOrganisations" })
    ]
    [HttpGet(ListOrganisationCommand.Route)]
    public override async Task<ActionResult<List<OrganisationRecord>>> HandleAsync([FromBody] ListOrganisationCommand request, CancellationToken cancellationToken = default)
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
