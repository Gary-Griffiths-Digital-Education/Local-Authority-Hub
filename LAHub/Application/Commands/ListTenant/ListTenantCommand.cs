using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.ListTenant;

public record TenantRecord(Guid Id, string Name, string? Description);
public class ListTenantCommand : IRequest<List<TenantRecord>>
{
}

public class ListTenantCommandHandler : IRequestHandler<ListTenantCommand, List<TenantRecord>>
{
    private readonly ILAHubDbContext _context;

    public ListTenantCommandHandler(ILAHubDbContext context)
    {
        _context = context;
    }
    public async Task<List<TenantRecord>> Handle(ListTenantCommand request, CancellationToken cancellationToken)
    {
        var tenants = await _context.Tenants.Select(org => new TenantRecord(org.Id, org.Name, org.Description)).ToListAsync();
        return tenants;
    }
}
