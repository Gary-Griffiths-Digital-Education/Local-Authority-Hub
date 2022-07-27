using LAHub.Domain.OpenReferralEnities;

namespace Infrastructure.Persistence.SeedData.Organisations;

public class OpenReferralOrganisationSeedData
{
    public IReadOnlyCollection<OpenReferralOrganisation> SeedOpenReferralOrganistions()
    {
        List<OpenReferralOrganisation> openReferralOrganistions = new()
        {
            GetBristolCountyCouncil()
        };

        return openReferralOrganistions;
    }

    private OpenReferralOrganisation GetBristolCountyCouncil()
    {
        var bristolCountyCouncil = new OpenReferralOrganisation(
            Guid.NewGuid().ToString(),
            "Bristol County Council",
            "Bristol County Council",
            null,
            new Uri("https://www.bristol.gov.uk/").ToString(),
            "https://www.bristol.gov.uk/",
            null,
            GetBristolCountyCouncilServices()
            );
        return bristolCountyCouncil;
    }

    private List<OpenReferralService> GetBristolCountyCouncilServices()
    {
        return new()
        {
            new OpenReferralService(
                Guid.NewGuid().ToString(),
                "Aid for Children with Tracheostomies",
                @"Aid for Children with Tracheostomies is a national self help group operating as a registered charity and is run by parents of children with a tracheostomy and by people who sympathise with the needs of such families. ACT as an organisation is non profit making, it links groups and individual members throughout Great Britain and Northern Ireland.",
                null,
                null,
                null,
                null,
                null,
                "active",
                "www.actfortrachykids.com",
                "support@ACTfortrachykids.com",
                null,
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
                        "", 
                        "", 
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
                            Guid.NewGuid().ToString(),
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

        };
    }

    /*
    private OpenReferralOrganisation GetSuffolkCountyCouncil()
    {
        var suffolkCountyCouncil = new OpenReferralOrganisation(
            Guid.NewGuid().ToString(),
            "Suffolk County Council",
            "Suffolk County Council",
            null,
            new Uri("https://www.suffolk.gov.uk/").ToString(),
            "https://www.suffolk.gov.uk/",
            null,
            GetSuffolkCountyCouncilServices()
        );

        return suffolkCountyCouncil;
    }

    private List<OpenReferralService> GetSuffolkCountyCouncilServices()
    {
        return new()
        {
            new OpenReferralService(
                Guid.NewGuid().ToString(),
                "Robins Childcare",
                @"Day nursery

A purpose built childcare establishment for 3 months to 11 years.

Seperate rooms for differing age groups.

2, 3 and 4 year old grant funding available.
Full day care and sessional care.

Wrap around and Out of School Care, including full care available out of term.",
                null,
                null,
                "3 month - 11 years old",
                "3 month - 11 years old",
                "Day Nursery",
                "Active",
                "http://www.robinschildcare.co.uk",
                "info@robinschildcare.co.uk",
                "Please contact the provider directly for cost information or look on their web site.",
                new List<OpenReferralEligibility>
                {
                    new OpenReferralEligibility(
                        Guid.NewGuid().ToString(),
                        "3 months - 11 years old",
                        null,
                        11,
                        1,
                        new List<OpenReferralTaxonomy>
                        {
                            new OpenReferralTaxonomy(
                                Guid.NewGuid().ToString(),
                                "Child Care",
                                "Service",
                                null, //To do
                                null
                                )
                        }

                        )
                    
                },
                new List<OpenReferralFunding>
                )
        };
    }
    */
}
