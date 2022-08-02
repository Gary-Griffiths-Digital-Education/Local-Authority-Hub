﻿using Application.Commands.GetOpenReferralTaxonomies;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints;

public class MinimalTaxonomyEndPoints
{
    public void RegisterTaxonomyEndPoints(WebApplication app)
    {
        app.MapGet("api/taxonomies", async (int? pageNumber, int? pageSize, string? text, CancellationToken cancellationToken, ISender _mediator) =>
        {
            try
            {
                GetOpenReferralTaxonomiesCommand command = new(pageNumber, pageSize, text);
                var result = await _mediator.Send(command, cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }).WithMetadata(new SwaggerOperationAttribute("Get All Taxonomies", "Get All Taxonomies") { Tags = new[] { "Services" } });

    }
}
