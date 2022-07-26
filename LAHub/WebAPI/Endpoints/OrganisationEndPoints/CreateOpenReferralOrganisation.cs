using Application.Commands.CreateOrganisation;
using Application.Commands.TestCommand;
using Ardalis.ApiEndpoints;
using LAHub.Domain.OpenReferralEnities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.OrganisationEndPoints;


public class GetOpenReferralOrganisationEndPoint : EndpointBaseAsync
    .WithRequest<OpenReferralOrganisation>
    .WithResult<ActionResult<List<OpenReferralOrganisation>>>
{
    [SwaggerOperation(
    Summary = "Creates an Open Referral Organisation",
    Description = "Creates an Open Referral Organisation",
    //OperationId = "Author.Create",
    Tags = new[] { "OpenReferralOrganisation" })
    ]
    [HttpPost]
    [Route("api/organizations")]
    public override async Task<ActionResult<List<OpenReferralOrganisation>>> HandleAsync([FromBody] OpenReferralOrganisation request, CancellationToken cancellationToken = default)
    {
        return await Task.Run(() => DoSomething(request, cancellationToken), cancellationToken);
    }

    private List<OpenReferralOrganisation> DoSomething(OpenReferralOrganisation OpenReferralOrganisation, CancellationToken token)
    {
        return new List<OpenReferralOrganisation>()
        {
            OpenReferralOrganisation
        };
    }
}

