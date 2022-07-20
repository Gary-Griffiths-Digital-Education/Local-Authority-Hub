using Application.Common.Mappings;
using AutoMapper;
using LAHub.Domain.Entities;

namespace Application.Models;

public class ServiceItem : IMapFrom<Service>
{
    public ServiceItem() { }
    public Guid Id { get; set; }    
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public int MinimumAge { get; set; }
    public int MaximumAge { get; set; }
    public string? CostAmount { get; set; }
    public string? CostDescription { get; set; }
    public string? OpeningHours { get; set; }
    public Guid? OrganisationId { get; set; }
    public virtual Organisation? Organisation { get; set; } = default!;
    public Guid? ContactId { get; private set; }
    public virtual Contact? Contact { get; set; } = default!;
    public Guid? LocationId { get; set; }
    public virtual Location? Location { get; set; } = default!;
    public ICollection<Classification> Classifications { get; set; } = default!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Service, ServiceItem>();
    }
}
