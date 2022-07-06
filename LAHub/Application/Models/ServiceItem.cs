using Application.Common.Mappings;
using AutoMapper;
using LAHub.Domain.Entities;

namespace Application.Models
{
    public class ServiceItem : IMapFrom<Service>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Service, ServiceItem>();
        }
    }
}
