using Application.Commands.ListTenant;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.TenantEndPoints;

public class ListTenants : EndpointBaseAsync
    .WithoutRequest
    .WithResult<ActionResult<List<TenantRecord>>>
{
    private ISender _mediator = null!;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    [SwaggerOperation(
    Summary = "List of Tenants",
    Description = "List of Tenants",
    OperationId = "Tenant.List",
    Tags = new[] { "ListTenants" })
    ]
    [HttpGet]
    [Route("api/ListTenantsDepricated")]
    public override async Task<ActionResult<List<TenantRecord>>> HandleAsync(CancellationToken cancellationToken = new())
    {

        try
        {
            ListTenantCommand request = new();
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
