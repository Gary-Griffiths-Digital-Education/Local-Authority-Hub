using Application.Commands.GetServices;
using Application.Common.Models;
using LAHub.Domain.OpenReferralEnities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints;

public class MinimalServiceEndPoints
{
    public void RegisterServiceEndPoints(WebApplication app)
    {
        //Http://localhost:portnumber/latitude/longtitude/meters?pageNumber=1&pageSize=10
        //string[]? taxonomy_id, string[]? taxonomy_type, string[]? vocabulary,
        app.MapGet("api/services", async (int? minimum_age, int? maximum_age, double ? latitude, double? longtitude, double? proximity, int? pageNumber, int? pageSize, string? text, CancellationToken cancellationToken, ISender _mediator) =>
        {
            try
            {
                GetOpenReferralServicesCommand command = new(minimum_age, maximum_age, latitude, longtitude, proximity, pageNumber, pageSize, text);
                var result = await _mediator.Send(command, cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }).WithMetadata(new SwaggerOperationAttribute("List Services", "List Services") { Tags = new[] { "Services" } });
    }
    
}
