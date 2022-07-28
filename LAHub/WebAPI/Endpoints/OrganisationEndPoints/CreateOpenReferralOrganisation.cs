using Application.Commands.CreateOpenReferralOrganisation;
using Ardalis.ApiEndpoints;
using LAHub.Domain.OpenReferralEnities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.OrganisationEndPoints;


public class GetOpenReferralOrganisationEndPoint : EndpointBaseAsync
    .WithRequest<OpenReferralOrganisation>
    //.WithResult<ActionResult<List<OpenReferralOrganisation>>>
    .WithResult<ActionResult<string>>
{

    private ISender _mediator = null!;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    [SwaggerOperation(
    Summary = "Creates an Open Referral Organisation",
    Description = "Creates an Open Referral Organisation",
    //OperationId = "Author.Create",
    Tags = new[] { "OpenReferralOrganisation" })
    ]
    [HttpPost]
    [Route("api/organizations")]
    //public override async Task<ActionResult<List<OpenReferralOrganisation>>> HandleAsync([FromBody] OpenReferralOrganisation request, CancellationToken cancellationToken = default)
    //{
    //    return await Task.Run(() => DoSomething(request, cancellationToken), cancellationToken);
    //}

    public override async Task<ActionResult<string>> HandleAsync([FromBody] OpenReferralOrganisation request, CancellationToken cancellationToken = default)
    {
        try
        {
            CreateOpenReferralOrganisationCommand command = new(request);
            var result = await Mediator.Send(command, cancellationToken);
            return result;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return BadRequest();
        }
    }

    private List<OpenReferralOrganisation> DoSomething(OpenReferralOrganisation OpenReferralOrganisation, CancellationToken token)
    {
        return new List<OpenReferralOrganisation>()
        {
            OpenReferralOrganisation
        };
    }
}

