using LAHub.Domain.Entities;
using System.Collections.ObjectModel;


namespace Infrastructure.Persistence.SeedData.Organisations
{
    public class OrganisationSeedData
    {
        private readonly IReadOnlyCollection<Tenant> _tenants = new List<Tenant>
        {
            new Tenant { Name = "Bir" },
            new Tenant { Name = "Bri" },
            new Tenant { Name = "Red" },
            new Tenant { Name = "Suf" },
            new Tenant { Name = "TH" },
        };

        private readonly IReadOnlyCollection<OrganisationType> _organisationTypes = new List<OrganisationType>
        {
            new OrganisationType { Name = "Local Authority" },
            new OrganisationType { Name = "Charity" }
        };

        public OrganisationSeedData() { }

        public IReadOnlyCollection<Organisation> SeedOrganistions()
        {
            var birminghamCityCouncil = new Organisation()
            {
                Tenant = _tenants?.Where(tenant => tenant.Name.Equals("Bir"))?.FirstOrDefault() ?? new Tenant(),
                Name = "Birmingham City Council",
                OrganisationType = _organisationTypes?.Where(organisationType => organisationType.Name.Equals("Local Authority"))?.FirstOrDefault() ?? new OrganisationType(),
                OrganisationContacts = new List<Contact>
                    {
                        new Contact(
                            _tenants?.Where(tenant => tenant.Name.Equals("Bir"))?.FirstOrDefault() ?? new Tenant(),
                            "Switchboard",
                            "Switchboard",
                            "0121 303 9944",
                            "Dial 18001 before the full national phone number.",
                            null,
                            null,
                            new Uri("https://www.birmingham.gov.uk/contactus"),
                            null,
                            null,
                            null,
                            "Council House",
                            "Victoria Square",
                            "Birmingham",
                            "West Midlands",
                            "B1 1BB",
                            "0121 303 1119 or 0121 675 8221"
                            )

                    }
            };

            Service service = new(
            "Service 1",
            "We supply this service",
            birminghamCityCouncil
            );

            birminghamCityCouncil.Services = new List<Service>() { service };

            var location = new LAHub.Domain.Entities.Location("Edgbaston",
            "Council House",
            52.48101394467345, -1.9041462501082664
            );

            ServiceLocation serviceLocation = new(service.Id, location.Id);
            serviceLocation.Service = service;
            serviceLocation.Location = location;

            service.ServiceLocations = new List<ServiceLocation>
            {
                serviceLocation
            };

            var organisations = new List<Organisation>()
            {

                birminghamCityCouncil,


                new Organisation()
                {
                    Tenant = new Tenant(),
                    Name = "Bristol City Council",
                    OrganisationType = _organisationTypes?.Where(organisationType => organisationType.Name.Equals("Local Authority"))?.FirstOrDefault() ?? new OrganisationType(),
                },
                new Organisation()
                {
                    Tenant = new Tenant(),
                    Name = "Redbridge Council",
                    OrganisationType = _organisationTypes?.Where(organisationType => organisationType.Name.Equals("Local Authority"))?.FirstOrDefault() ?? new OrganisationType(),
                },
                new Organisation
                {
                    Tenant = new Tenant(),
                    Name = "Suffolk County Council",
                    OrganisationType = _organisationTypes?.Where(organisationType => organisationType.Name.Equals("Local Authority"))?.FirstOrDefault() ?? new OrganisationType(),
                    Services = new List<Service>()
                    {

                    }
                    
                },
                
                new Organisation()
                {
                    Tenant = new Tenant(),
                    Name = "Tower Hamlets Council"
                }
            };

            return new ReadOnlyCollection<Organisation>(organisations);
        }
    }
}
