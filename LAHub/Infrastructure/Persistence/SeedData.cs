using GeoAPI.Geometries;
using LAHub.Domain;
using LAHub.Domain.Entities;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace Infrastructure.Persistence;


// find 52.47747187167772, 1.7507070439319121
public class SeedData
{
    private readonly LAHubDbContext _context;
    public SeedData(LAHubDbContext context)
    {
        _context = context;
    }

    public async Task AddServices()
    {
        if (_context.Organisations.Any())
            return;

        await AddOrganisation("Activities Unlimited"
            , "Activities Unlimited is a short break service for disabled children and young people in Suffolk. Families who have children with additional needs can visit their website, register their child(ren) to become a memeber and then book lots of exciting activities and short breaks online."
            , 52.05440646936693, 
            1.143434288801912);

        await AddOrganisation("A&A Healthcare Services Ltd"
            , "A&A Healthcare is a specialist community based support provider, geared towards providing rehabilitative and supported living resources, for vulnerable adults and vulnerable young people. We specialise in providing holistic and comprehensive support packages for people with learning disabilities, aspergers/autistic spectrum disorders, mental health needs, and challenging behaviours."
            , 52.04954845332707, 1.1579650483184487);

        await AddOrganisation("A1MOBILITY.ORG.UK"
            ,@"We provide stair lifts, curved and straights, scooters, scooter covers, wheelchairs, both push and power assisted, collapsible chairs, and those with special tires.

We also provide bath lifts and seating, general bed lifts, special beds and mattresses, and batteries.
We also offer a repair service to any of the above, in and out of warranty."
            , 52.830693734368545, 0.872662802033019);

        await AddOrganisation("Access Community Trust"
            , @"We support people who may be homeless, vulnerable and suffering from social exclusion. We believe that everyone, irrespective of their background and circumstance, is entitled to live in a decent home, enjoy positive and rewarding relationships with others, engage in meaningful activities and achieve their maximum potential."
            , 52.477772464444094, 1.751994504154493);

    }

    private async Task AddOrganisation(string name, string description, double latitude, double logtitude)
    {
        Organisation organisation = new(
            name
            , description
            , null
            , null
        );

        _context.Organisations.Add(organisation);

        var location = new LAHub.Domain.Entities.Location(name
            , description
                , 52.05440646936693, 1.143434288801912
                );

        location.LocationPoint = Helper.CreatePoint(location.Latitude, location.Longitude);

        _context.Locations.Add(location);

        var serviceItem = new Service(
                name
            , description
                , organisation.Id
                , organisation
                );

        _context.Services.Add(serviceItem);

        var serviceLocation = new ServiceLocation(serviceItem.Id, location.Id);

        serviceItem.ServiceLocations = new List<ServiceLocation>()
        {
            serviceLocation
        };

        organisation.Services = new List<Service>()
        {
            serviceItem
        };

        _context.ServiceLocations.Add(serviceLocation);

        await _context.SaveChangesAsync();
    }

    public async Task AddContactMechanismTypes()
    {
        if (_context.ContactMechanismTypes.Any())
            return;

        List<ContactMechanismType> contactMechanismTypes = new()
            {
                new ContactMechanismType
                {
                    Id = Guid.NewGuid(),
                    Name = "Phone",
                    Description = "Phone number",
                    Created = DateTime.Now,
                    CreatedBy = "System"
                },
                new ContactMechanismType
                {
                    Id = Guid.NewGuid(),
                    Name = "Email",
                    Description = "Email address",
                    Created = DateTime.Now,
                    CreatedBy = "System"
                }
            };

        foreach (var contactMechanismType in contactMechanismTypes)
        {
            _context.ContactMechanismTypes.Add(contactMechanismType);
        }

        await _context.SaveChangesAsync();
    }

    public async Task AddServiceOptionTypes()
    {
        if (_context.ServiceOptionTypes.Any())
            return;

        List<ServiceOptionType> serviceOptionTypes = new()
        {
            new ServiceOptionType
            {
                Name = "Orgaisation",
                Description = "Organisation providing one or more services",
                Created = DateTime.Now,
                CreatedBy = "System"
            },
            new ServiceOptionType
            {
                Name = "Eligability",
                Description = "Eligability of people who can use the service",
                Created = DateTime.Now,
                CreatedBy = "System"
            },
        };

        foreach (var serviceOptionType in serviceOptionTypes)
        {
            _context.ServiceOptionTypes.Add(serviceOptionType);
        }

        await _context.SaveChangesAsync();
    }
    
}
