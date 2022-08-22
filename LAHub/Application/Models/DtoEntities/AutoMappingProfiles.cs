using AutoMapper;
using LAHub.Domain.OpenReferralEnities;
using LAHub.Domain.RecordEntities;

namespace Application.Models.DtoEntities;

public class AutoMappingProfiles : Profile
{
    public AutoMappingProfiles()
    {
        CreateMap<OpenReferralContactRecord, OpenReferralContact>();
        CreateMap<OpenReferralCost_OptionRecord, OpenReferralCost_Option>();
        CreateMap<OpenReferralEligibilityRecord, OpenReferralEligibility>();
        CreateMap<OpenReferralLanguageRecord, OpenReferralLanguage>();
        CreateMap<OpenReferralLocationRecord, OpenReferralLocation>();
        CreateMap<OpenReferralOrganisationWithServicesRecord, OpenReferralOrganisation>();
        CreateMap<OpenReferralPhoneRecord, OpenReferralPhone>();
        CreateMap<OpenReferralPhysical_AddressRecord, OpenReferralPhysical_Address>();
        CreateMap<OpenReferralService_AreaRecord, OpenReferralService_Area>();
        CreateMap<OpenReferralService_TaxonomyRecord, OpenReferralService_Taxonomy>();
        CreateMap<OpenReferralServiceAtLocationRecord, OpenReferralServiceAtLocation>();
        CreateMap<OpenReferralServiceDeliveryRecord, OpenReferralServiceDeliveryEx>();
        CreateMap<OpenReferralServiceRecord, OpenReferralService>();
        CreateMap<OpenReferralTaxonomyRecord, OpenReferralTaxonomy>();

    }
}
