using AutoMapper;
using LAHub.Domain.Entities;

namespace Application.Models.DtoEntities;

public class AutoMappingProfiles : Profile
{
    public AutoMappingProfiles()
    {
        CreateMap<Organisation, OrganisationDto>().ReverseMap();
        CreateMap<Address, AddressDto>().ReverseMap();
        CreateMap<Classification, ClassificationDto>().ReverseMap();
        CreateMap<Contact, ContactDto>().ReverseMap();
        CreateMap<Location, LocationDto>().ReverseMap();
        CreateMap<OrganisationType, OrganisationTypeDto>().ReverseMap();
        
        CreateMap<ServiceClassification, ServiceClassificationDto>().ReverseMap();
        CreateMap<Service, ServiceDto>().ReverseMap();
        CreateMap<Tenant, TenantDto>().ReverseMap();
        CreateMap<Service, ServiceItem>().ReverseMap();
    }
}
