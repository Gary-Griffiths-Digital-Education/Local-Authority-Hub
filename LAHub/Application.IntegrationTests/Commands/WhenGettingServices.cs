using Application.Commands.GetServices;
using FluentAssertions;
using LAHub.Domain.OpenReferralEnities;
using System.Collections.ObjectModel;

namespace Application.IntegrationTests.Commands;

using static Testing;


public  class WhenGettingServices : BaseTestFixture
{
    private readonly Testing _testing;
    public WhenGettingServices()
    {
        _testing = TestHelper.CreateTesting();
    }

    
    [Fact]
    public async Task ThenShouldReturnListOfServices()
    {
        // Assign
        await RunAsDefaultUserAsync();

        OpenReferralOrganisation openReferralOrganisation = GetTestOrganisation();

        await AddAsync(openReferralOrganisation);

        var query = new GetOpenReferralServicesCommand(null, null, 52.0, -1.7, 212892, 1, 10, null);

        var result = await SendAsync(query);

        result.Should().NotBeNull();
        result.Items.Count.Should().BeGreaterThanOrEqualTo(2);
    }

    private OpenReferralOrganisation GetTestOrganisation()
    {
        var testCountyCouncil = new OpenReferralOrganisation(
            "92dbfcea-6d08-444f-94d8-db64ac86ec8c",
            "Test County Council",
            "Test County Council",
            null,
            new Uri("https://www.testcouncil.gov.uk/").ToString(),
            "https://www.testcouncil.gov.uk/",
            new Collection<OpenReferralReview>(),
            TestCountyCouncilServices()
            );
        return testCountyCouncil;

    }

    private List<OpenReferralService> TestCountyCouncilServices()
    {
        return new()
        {
            new OpenReferralService(
                "17f7fa15-349d-471a-b078-455ab94dcf36",
                "Service 1 Name",
                @"Service 1 Description",
                null,
                null,
                null,
                null,
                null,
                "active",
                "www.service1.com",
                "support@service1.com",
                null,
                new List<OpenReferralServiceDelivery>
                {
                    new OpenReferralServiceDelivery("d79c612a-7bdd-4646-99a9-c0cc2fdf97e2",ServiceDelivery.Online)
                },
                new List<OpenReferralEligibility>
                {
                    new OpenReferralEligibility("Test1","",null,0,13,new List<OpenReferralTaxonomy>())
                },
                new List<OpenReferralFunding>(),
                new List<OpenReferralHoliday_Schedule>(),
                new List<OpenReferralLanguage>(),
                new List<OpenReferralRegular_Schedule>(),
                new List<OpenReferralReview>(),
                new List<OpenReferralContact>()
                {
                    new OpenReferralContact(
                        "1",
                        "Mr",
                        "Peter Smith",
                        new List<OpenReferralPhone>()
                        {
                            new OpenReferralPhone("1", "01827 65779")
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
                        "Test1749",
                        new OpenReferralLocation(
                            "c64f5379-875d-4d56-a65d-08a0aaddb1ba",
                            "",
                            "",
                            52.0,
                            -1.7,
                            new List<OpenReferralPhysical_Address>()
                            {
                                new OpenReferralPhysical_Address(
                                    Guid.NewGuid().ToString(),
                                    "76 Sheepcote Lane",
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
                    ("Test9107",
                    null,
                    new OpenReferralTaxonomy(
                        "test:Organisation",
                        "Test Organisation",
                        "Test Data Sources",
                        null
                        )),

                    new OpenReferralService_Taxonomy
                    ("Test9108",
                    null,
                    new OpenReferralTaxonomy(
                        "test:38",
                        "Test Support",
                        "Test Primary Services",
                        null
                        )),

                    new OpenReferralService_Taxonomy
                    ("Test9109",
                    null,
                    new OpenReferralTaxonomy(
                        "Test:37",
                        "Test Children",
                        "Test Age Groups",
                        null
                        )),

                    new OpenReferralService_Taxonomy
                    ("Test9110",
                    null,
                    new OpenReferralTaxonomy(
                        "Test:56",
                        "Test Long Term Health Conditions",
                        "Test User Groups",
                        null
                        ))
                }
                )

        };
    }

}
