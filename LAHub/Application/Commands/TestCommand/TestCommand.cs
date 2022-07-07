using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Application.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LAHub.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.TestCommand;

public class TestItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Name { get; set; }
    public string? Description { get; set; }

}

public class TestCommand : IRequest<PaginatedList<TestItem>>
{
    public TestCommand(double latitude, double longtitude, double meters, int pageNumber = 1, int pageSize = 10)
    {
        Latitude = latitude;
        Longtitude = longtitude;
        Meters = meters;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    public double Latitude { get; init; }
    public double Longtitude { get; init; }
    public double Meters { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetTestCommandCommandHandler : IRequestHandler<TestCommand, PaginatedList<TestItem>>
{
    private readonly ILAHubDbContext _context;
    private readonly IMapper _mapper;

    public GetTestCommandCommandHandler(ILAHubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<PaginatedList<TestItem>> Handle(TestCommand request, CancellationToken cancellationToken)
    {
        return await Task.Run(() => GetItemList());  
    }

    private PaginatedList<TestItem> GetItemList()
    {
        List<TestItem> result = new List<TestItem>()
        {
            new TestItem(){ Name = "name", Description = "description" },
        };

        PaginatedList<TestItem> paginatedList = new()
        {
            Items = result,
            PageNumber = 1,
            TotalPages = 1,
            TotalCount = 1

        };
        

        return paginatedList;
    }


}
