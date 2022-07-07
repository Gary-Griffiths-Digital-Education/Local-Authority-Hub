using Application.Common.Mappings;
using AutoMapper;
using LAHub.Domain.Entities;

namespace Application.Models
{
    public class ServiceItem : IMapFrom<Service>
    {
        public ServiceItem() { }
        public string Name { get; set; } = default!;

        public string? Description { get; set; }

        public Guid OrganisationId { get; set; }
        public virtual Organisation? Organisation { get; set; } = default!;
        public ICollection<ServiceLocation> ServiceLocations { get; set; } = default!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Service, ServiceItem>();
        }
    }
}
