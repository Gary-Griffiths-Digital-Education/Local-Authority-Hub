using Application.Common.Interfaces;
using Application.Common.Models;
using LAHub.Domain.OpenReferralEnities;
using LAHub.Domain.RecordEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.GetOpenReferralTaxonomies;

public class GetOpenReferralTaxonomiesCommand : IRequest<PaginatedList<OpenReferralTaxonomyRecord>>
{
    public GetOpenReferralTaxonomiesCommand(int? pageNumber, int? pageSize, string? text)
    {
        PageNumber = (pageNumber != null) ? pageNumber.Value : 1;
        PageSize = (pageSize != null) ? pageSize.Value : 1;
        Text = text;
    }

    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? Text { get; set; }
}

public class GetOpenReferralTaxonomiesCommandHandler : IRequestHandler<GetOpenReferralTaxonomiesCommand, PaginatedList<OpenReferralTaxonomyRecord>>
{
    private readonly ILAHubDbContext _context;

    public GetOpenReferralTaxonomiesCommandHandler(ILAHubDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedList<OpenReferralTaxonomyRecord>> Handle(GetOpenReferralTaxonomiesCommand request, CancellationToken cancellationToken)
    {
        var entities = await _context.OpenReferralTaxonomies.ToListAsync();

        if (request.Text != null)
        {
            entities = entities.Where(x => x.Name.Contains(request.Text)).ToList();
        }

        var filteredTaxonomies = entities.Select(x => new OpenReferralTaxonomyRecord(
            x.Id,
            x.Name,
            x.Vocabulary,
            x.Parent
            )).ToList();

        if (request != null)
        {
            var pagelist = filteredTaxonomies.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
            var result = new PaginatedList<OpenReferralTaxonomyRecord>(filteredTaxonomies, pagelist.Count, request.PageNumber, request.PageSize);
            return result;
        }

        return new PaginatedList<OpenReferralTaxonomyRecord>(filteredTaxonomies, filteredTaxonomies.Count, 1, 10);
    }
}