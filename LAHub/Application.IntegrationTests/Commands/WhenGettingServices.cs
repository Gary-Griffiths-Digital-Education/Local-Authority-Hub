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
        _testing = new Testing();
        
        _testing.RunBeforeAnyTests();
        Task.Run(() => Testing.ResetState()).Wait();

    }

    
    [Fact]
    public async Task ThenShouldReturnListOfServices()
    {
        // Assign
        await RunAsDefaultUserAsync();
        Organisation organisation = new("Organisation 1",
        "This is Organisation 1",
        null,
        null);

        Service service = new(
            "Service 1",
            "We supply this service",
            organisation.Id,
            organisation
            );

        var location = new LAHub.Domain.Entities.Location("Edgbaston",
        "Edgbaston",
        52.45,
        -1.92
                );

        location.LocationPoint = Helper.CreatePoint(location.Latitude, location.Longitude);

        ServiceLocation serviceLocation = new(service.Id, location.Id);

        service.ServiceLocations = new List<ServiceLocation>
        {
            serviceLocation
        };

        
        await AddAsync(service);


        var query = new GetServicesByDistanceCommand(52.394, -1.93, 3.1);

        var result = await SendAsync(query);

        result.Should().NotBeNull();
    }
    
}
