using Application.Commands.GetServices;
using FluentAssertions;
using LAHub.Domain;
using LAHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IntegrationTests.Commands;

using static Testing;
public  class WhenGettingServices : BaseTestFixture
{
    private readonly Testing _testing;
    public WhenGettingServices()
    {
        _testing = TestHelper.CreateTesting();
    }

    
    //[Fact]
    //public async Task ThenShouldReturnListOfServices()
    //{
    //    // Assign
    //    await RunAsDefaultUserAsync();

    //    Tenant tenant = new("Tenant 1", "Tenant 1");
    //    OrganisationType organisationType = new OrganisationType("LA", "Local Authority");


    //    Organisation organisation = new(
    //        tenant,
    //        organisationType,
    //    "Organisation 1",
    //    "This is Organisation 1",
    //    null,
    //    Guid.Empty);

    //    Service service = new(
    //        "Service 1",
    //        "We supply this service",
    //        organisation
    //        );

    //    organisation.Services = new List<Service>() { service };

    //    var location = new LAHub.Domain.Entities.Location("Edgbaston",
    //    "Edgbaston",
    //    52.45,
    //    -1.92
    //    );

    //    ServiceLocation serviceLocation = new(service.Id, location.Id);
    //    serviceLocation.Service = service;
    //    serviceLocation.Location = location;

    //    service.ServiceLocations = new List<ServiceLocation>
    //    {
    //        serviceLocation
    //    };

        
    //    await AddAsync(organisation);

    //    var query = new GetServicesByDistanceCommand(52.394, -1.93, 212892);

    //    var result = await SendAsync(query);

    //    result.Should().NotBeNull();
    //    result.Items.Count.Should().Be(2);
    //}
    
}
