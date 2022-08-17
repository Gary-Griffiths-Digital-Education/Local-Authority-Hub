using LAHub.Domain.OpenReferralEnities;
using System.Collections.ObjectModel;
using WebUI.Models;

namespace WebUI.Services;

public class ViewModelToApiModelHelper
{
    public static OpenReferralOrganisation GetOrganisation(OrganisationViewModel viewModel)
    {
        

        var organisation = new OpenReferralOrganisation(
            viewModel.Id.ToString(),
            viewModel.Name,
            viewModel.Description,
            viewModel.Logo,
            new Uri(viewModel.Url ?? string.Empty).ToString(),
            viewModel.Url,
            new Collection<OpenReferralReview>(),
            new List<OpenReferralService>()
        {
            new OpenReferralService(
                viewModel.ServiceId ?? Guid.NewGuid().ToString(),
                viewModel.ServiceName ?? string.Empty,
                viewModel.ServiceDescription,
                null,
                null,
                null,
                null,
                null,
                "pending",
                "www.actfortrachykids.com",
                "support@ACTfortrachykids.com",
                null,
                GetDeliveryTypes(viewModel.ServiceDeliverySelection),
                new List<OpenReferralEligibility>
                {
                    new OpenReferralEligibility("9109Children","",null,0,13,new List<OpenReferralTaxonomy>())
                },
                new List<OpenReferralFunding>(),
                new List<OpenReferralHoliday_Schedule>(),
                new List<OpenReferralLanguage>(),
                new List<OpenReferralRegular_Schedule>(),
                new List<OpenReferralReview>(),
                new List<OpenReferralContact>()
                {
                    new OpenReferralContact(
                        "1567",
                        "Mr",
                        "John Smith",
                        new List<OpenReferralPhone>()
                        {
                            new OpenReferralPhone("1567", "01827 65778")
                        }
                        )
                },
                new List<OpenReferralCost_Option>(),
                new List<OpenReferralService_Area>()
                {
                    new OpenReferralService_Area(Guid.NewGuid().ToString(), "National", null, null, "http://statistics.data.gov.uk/id/statistical-geography/K02000001")
                },
                new List<OpenReferralServiceAtLocation>()
                {
                    new OpenReferralServiceAtLocation(
                        "1749",
                        new OpenReferralLocation(
                            "256d0b97-d4c4-48e8-9475-bd7d42d1fc69",
                            "",
                            "",
                            52.6312,
                            -1.66526,
                            new List<OpenReferralPhysical_Address>()
                            {
                                new OpenReferralPhysical_Address(
                                    Guid.NewGuid().ToString(),
                                    "75 Sheepcote Lane",
                                    ", Stathe, Tamworth, Staffordshire, ",
                                    "B77 3JN",
                                    "England",
                                    null
                                    )
                            },
                            new List<Accessibility_For_Disabilities>()
                            ),
                        new List<OpenReferralHoliday_Schedule>(),
                        new List<OpenReferralRegular_Schedule>()
                        )

                },
                new List<OpenReferralService_Taxonomy>()
                {
                    new OpenReferralService_Taxonomy
                    ("9107",
                    null,
                    new OpenReferralTaxonomy(
                        "bccsource:Organisation",
                        "Organisation",
                        "BCC Data Sources",
                        null
                        )),

                    new OpenReferralService_Taxonomy
                    ("9108",
                    null,
                    new OpenReferralTaxonomy(
                        "bccprimaryservicetype:38",
                        "Support",
                        "BCC Primary Services",
                        null
                        )),

                    new OpenReferralService_Taxonomy
                    ("9109",
                    null,
                    new OpenReferralTaxonomy(
                        "bccagegroup:37",
                        "Children",
                        "BCC Age Groups",
                        null
                        )),

                    new OpenReferralService_Taxonomy
                    ("9110",
                    null,
                    new OpenReferralTaxonomy(
                        "bccusergroup:56",
                        "Long Term Health Conditions",
                        "BCC User Groups",
                        null
                        ))
                }
                )

        });

        return organisation;
    }

    private static List<OpenReferralServiceDelivery> GetDeliveryTypes(List<string>? serviceDeliverySelection)
    {
        List<OpenReferralServiceDelivery> list = new();
        if (serviceDeliverySelection == null)
            return list;

        foreach(var serviceDelivery in serviceDeliverySelection)
        {
            switch(serviceDelivery)
            {

                case "In Person":
                    list.Add(new OpenReferralServiceDelivery(Guid.NewGuid().ToString(), ServiceDelivery.InPerson));
                    break;
                case "Online":
                    list.Add(new OpenReferralServiceDelivery(Guid.NewGuid().ToString(), ServiceDelivery.Online));
                    break;
                case "Telephone":
                    list.Add(new OpenReferralServiceDelivery(Guid.NewGuid().ToString(), ServiceDelivery.Telephone));
                    break;
            }
        }

        return list;
    }

    private static List<OpenReferralEligibility> GetEligibilities()
    {
        List<OpenReferralEligibility> list = new();

        return list;
    }
}
