using Application.Commands.GetServices;
using FluentAssertions;


namespace Application.IntegrationTests.Commands;

using static Testing;

/*
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

        Tenant tenant = new("Tenant 1", "Tenant 1");
        OrganisationType organisationType = new("LA", "Local Authority");

        IReadOnlyCollection<Classification> classifications = new List<Classification>
        {
            new Classification("Autism", "Autism" ),
            new Classification("Brest Feeding", "Brest Feeding Support" ),
        };


    Organisation organisation = new(
            tenant,
            organisationType,
        "Organisation 1",
        "This is Organisation 1",
        null,
        null,
        null);

        var location = new LAHub.Domain.Entities.Location("Edgbaston",
        "Edgbaston",
        52.45,
        -1.92,
        null
        );

        Service service = new(
            "Service 1",
            "We supply this service",
            3,
            25,
            "Free",
            "Free",
            "9am to 5pm",
            organisation,
            null, //contact,
            location
            );


        organisation.Services = new List<Service>() { service };
        
        await AddAsync(organisation);

        var query = new GetServicesByDistanceCommand(52.394, -1.93, 212892);

        var result = await SendAsync(query);

        result.Should().NotBeNull();
        result.Items.Count.Should().BeGreaterThanOrEqualTo(2);
    }
    
}
*/