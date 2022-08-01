﻿using Application.Commands.CreateOpenReferralOrganisation;
using Application.Commands.GetOpenReferralOrganisationById;
using Application.Commands.ListOrganisation;
using LAHub.Domain.OpenReferralEnities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints;

public class MinimalOrganisationEndPoints
{
    public void RegisterOrganisationEndPoints(WebApplication app)
    {
        app.MapPost("api/organizations", async ([FromBody] OpenReferralOrganisation request, CancellationToken cancellationToken, ISender _mediator) =>
        {
            try
            {
                CreateOpenReferralOrganisationCommand command = new(request);
                var result = await _mediator.Send(command, cancellationToken);
                return result;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        });

        app.MapGet("api/organizations/{id}", async (string id, CancellationToken cancellationToken, ISender _mediator) =>
        {
            try
            {
                GetOpenReferralOrganisationByIdCommand request = new()
                {
                    Id = id
                };
                var result = await _mediator.Send(request, cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        });

        app.MapGet("api/organizations", async (CancellationToken cancellationToken, ISender _mediator) =>
        {
            try
            {
                ListOpenReferralOrganisationCommand request = new();
                var result = await _mediator.Send(request, cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        });

        app.MapPut("api/organizations/{id}", async (string id, [FromBody] OpenReferralOrganisation request, CancellationToken cancellationToken, ISender _mediator) =>
        {
            try
            {
                UpdateOpenReferralOrganisationCommand command = new(id, request);
                var result = await _mediator.Send(command, cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        });
    }
}