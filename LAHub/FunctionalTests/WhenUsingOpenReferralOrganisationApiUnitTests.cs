using LAHub.Domain.OpenReferralEnities;
using System.Text;
using System.Text.Json;
using WebAPI.Endpoints;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace FunctionalTests;

[Collection("Sequential")]
public class WhenUsingOpenReferralOrganisationApiUnitTests
{
    private readonly HttpClient _client;

    public WhenUsingOpenReferralOrganisationApiUnitTests()
    {
        var webAppFactory = new WebApplicationFactory<Program>();

        _client = webAppFactory.CreateDefaultClient();
        _client.BaseAddress = new Uri("https://localhost:7128/");
    }

    [Fact]
    public async Task ThenTheOpenReferralOrganisationIsCreated()
    {
        var command = GetTestCountyCouncil();

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(_client.BaseAddress + "api/organizations"),
            Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json"),
        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var stringResult = await response.Content.ReadAsStringAsync();

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        stringResult.ToString().Should().Be("ba1cca90-b02a-4a0b-afa0-d8aed1083c0d");
        //string retVal = await JsonSerializer.DeserializeAsync<string>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


    }

    public IReadOnlyCollection<OpenReferralOrganisation> GetTestOpenReferralOrganistions()
    {
        List<OpenReferralOrganisation> openReferralOrganistions = new()
        {
            GetTestCountyCouncil()
        };

        return openReferralOrganistions;
    }

    private OpenReferralOrganisation GetTestCountyCouncil()
    {
        var bristolCountyCouncil = new OpenReferralOrganisation(
            "ba1cca90-b02a-4a0b-afa0-d8aed1083c0d",
            "Test County Council",
            "Test County Council",
            null,
            new Uri("https://www.test.gov.uk/").ToString(),
            "https://www.test.gov.uk/",
            null,
            GetTestCountyCouncilServices()
            );
        return bristolCountyCouncil;
    }

    private List<OpenReferralService> GetTestCountyCouncilServices()
    {
        return new()
        {
            new OpenReferralService(
                "d79b0584-ebd0-40a9-a9a9-c396a1ce090b",
                "Test Organisation for Children with Tracheostomies",
                @"Test Organisation for for Children with Tracheostomies is a national self help group operating as a registered charity and is run by parents of children with a tracheostomy and by people who sympathise with the needs of such families. ACT as an organisation is non profit making, it links groups and individual members throughout Great Britain and Northern Ireland.",
                null,
                null,
                null,
                null,
                null,
                "active",
                "www.testservice.com",
                "support@testservice.com",
                null,
                new List<OpenReferralEligibility>
                {
                    new OpenReferralEligibility("Test9109Children","",null,0,13,new List<OpenReferralTaxonomy>())
                },
                new List<OpenReferralFunding>(),
                new List<OpenReferralHoliday_Schedule>(),
                new List<OpenReferralLanguage>(),
                new List<OpenReferralRegular_Schedule>(),
                new List<OpenReferralReview>(),
                new List<OpenReferralContact>()
                {
                    new OpenReferralContact(
                        "Test1567",
                        "",
                        "",
                        new List<OpenReferralPhone>()
                        {
                            new OpenReferralPhone("1568", "01827 65779")
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
                            "a878aadc-6097-4a0f-b3e1-77fd4511175d",
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
                    ("Test9107",
                    null,
                    new OpenReferralTaxonomy(
                        "Test bccsource:Organisation",
                        "Organisation",
                        "Test BCC Data Sources",
                        null
                        )),

                    new OpenReferralService_Taxonomy
                    ("Test9108",
                    null,
                    new OpenReferralTaxonomy(
                        "Test bccprimaryservicetype:38",
                        "Support",
                        "Test BCC Primary Services",
                        null
                        )),

                    new OpenReferralService_Taxonomy
                    ("Test9109",
                    null,
                    new OpenReferralTaxonomy(
                        "Test bccagegroup:37",
                        "Children",
                        "Test BCC Age Groups",
                        null
                        )),

                    new OpenReferralService_Taxonomy
                    ("Test9110",
                    null,
                    new OpenReferralTaxonomy(
                        "Testbccusergroup:56",
                        "Long Term Health Conditions",
                        "Test BCC User Groups",
                        null
                        ))
                }
                )

        };
    }
}
