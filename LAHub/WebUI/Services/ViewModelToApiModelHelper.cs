using Application.Common.Models;
using LAHub.Domain.OpenReferralEnities;
using LAHub.Domain.RecordEntities;
using WebUI.Models;
using WebUI.Services.Api;

namespace WebUI.Services;

public interface IViewModelToApiModelHelper
{
    Task<OpenReferralOrganisationWithServicesRecord> GetOrganisation(OrganisationViewModel viewModel, double latitude, double longtitude);
}

public class ViewModelToApiModelHelper : IViewModelToApiModelHelper
{
    private readonly IOpenReferralOrganisationAdminClientService _openReferralOrganisationAdminClientService;
    public ViewModelToApiModelHelper(IOpenReferralOrganisationAdminClientService openReferralOrganisationAdminClientService)
    {
        _openReferralOrganisationAdminClientService = openReferralOrganisationAdminClientService;
    }
    
    public async Task<OpenReferralOrganisationWithServicesRecord> GetOrganisation(OrganisationViewModel viewModel, double latitude, double longtitude)
    {
        var contactId = Guid.NewGuid().ToString();

        var organisation = new OpenReferralOrganisationWithServicesRecord(
            viewModel.Id.ToString(),
            viewModel.Name,
            viewModel.Description,
            viewModel.Logo,
            new Uri(viewModel.Url ?? string.Empty).ToString(),
            viewModel.Url,
            new List<OpenReferralServiceRecord>()
        {
            new OpenReferralServiceRecord(
                viewModel.ServiceId ?? Guid.NewGuid().ToString(),
                viewModel.ServiceName ?? string.Empty,
                viewModel.ServiceDescription,
                null,
                null,
                null,
                null,
                null,
                "pending",
                viewModel.Website,
                viewModel.Email,
                null,
                GetDeliveryTypes(viewModel.ServiceDeliverySelection),
                GetEligibilities("Children", viewModel.MinAge ?? 0, viewModel.MaxAge ?? 0),
                new List<OpenReferralContactRecord>()
                {
                    new OpenReferralContactRecord(
                        contactId,
                        string.Empty,
                        string.Empty,
                        new List<OpenReferralPhoneRecord>()
                        {
                            new OpenReferralPhoneRecord(contactId, viewModel.Telephone ?? string.Empty)
                        }
                        )
                }
                , GetLanguages(viewModel.Languages)
                , new List<OpenReferralService_AreaRecord>()
                {
                    new OpenReferralService_AreaRecord(Guid.NewGuid().ToString(), "Local", null, "http://statistics.data.gov.uk/id/statistical-geography/K02000001")
                
                }
                , new List<OpenReferralServiceAtLocationRecord>()
                {
                    new OpenReferralServiceAtLocationRecord(
                        Guid.NewGuid().ToString(),
                        new OpenReferralLocationRecord(
                            Guid.NewGuid().ToString(),
                            "Our Location",
                            "",
                            latitude,
                            longtitude,
                            new List<OpenReferralPhysical_AddressRecord>()
                            {
                                new OpenReferralPhysical_AddressRecord(
                                    Guid.NewGuid().ToString(),
                                    viewModel.Address_1 ?? string.Empty,
                                    viewModel.City ?? string.Empty,
                                    viewModel.Postal_code ?? string.Empty,
                                    "England",
                                    viewModel.State_province ?? string.Empty
                                    )
                            }
                        ))
                }
                , await GetOpenReferralTaxonomies(viewModel.TaxonomySelection)
                )
            }); 
            
        return organisation;
    }

    private List<OpenReferralServiceDeliveryRecord> GetDeliveryTypes(List<string>? serviceDeliverySelection)
    {
        List<OpenReferralServiceDeliveryRecord> list = new();
        if (serviceDeliverySelection == null)
            return list;

        foreach(var serviceDelivery in serviceDeliverySelection)
        {
            switch(serviceDelivery)
            {

                case "In Person":
                    list.Add(new OpenReferralServiceDeliveryRecord(Guid.NewGuid().ToString(), ServiceDelivery.InPerson));
                    break;
                case "Online":
                    list.Add(new OpenReferralServiceDeliveryRecord(Guid.NewGuid().ToString(), ServiceDelivery.Online));
                    break;
                case "Telephone":
                    list.Add(new OpenReferralServiceDeliveryRecord(Guid.NewGuid().ToString(), ServiceDelivery.Telephone));
                    break;
            }
        }

        return list;
    }

    private List<OpenReferralEligibilityRecord> GetEligibilities(string whoFor, int minAge, int maxAge)
    {
        List<OpenReferralEligibilityRecord> list = new();

        list.Add(new OpenReferralEligibilityRecord(Guid.NewGuid().ToString(), whoFor, maxAge, minAge));

        return list;
    }

    private async Task<List<OpenReferralService_TaxonomyRecord>> GetOpenReferralTaxonomies(List<string>? taxonomySelection)
    {
        List<OpenReferralService_TaxonomyRecord> openReferralTaxonomyRecords = new();

        PaginatedList<OpenReferralTaxonomyRecord> taxonomies = await _openReferralOrganisationAdminClientService.GetTaxonomyList(1, 9999);

        if (taxonomies != null && taxonomySelection != null)
        {
            foreach (string taxonomyKey in taxonomySelection)
            {
                OpenReferralTaxonomyRecord? taxonomy = taxonomies.Items.FirstOrDefault(x => x.Id == taxonomyKey);
                if (taxonomy != null)
                {
                    
                    openReferralTaxonomyRecords.Add(new OpenReferralService_TaxonomyRecord(Guid.NewGuid().ToString(), taxonomy));
                }
            }
        }

        return openReferralTaxonomyRecords;
    }

    private List<OpenReferralLanguageRecord> GetLanguages(List<string>? viewModellanguages)
    {
        List<OpenReferralLanguageRecord> languages = new();

        if (viewModellanguages != null)
        {
            foreach (string lang in viewModellanguages)
            {
                languages.Add(new OpenReferralLanguageRecord(Guid.NewGuid().ToString(), lang));
            }
        }

        return languages;
    }
}
