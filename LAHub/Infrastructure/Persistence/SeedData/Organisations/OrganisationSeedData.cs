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
            var organisations = new List<Organisation>()
            {
                /*
                new Organisation()
                {
                    Tenant = _tenants?.Where(tenant => tenant.Name.Equals("Bir"))?.FirstOrDefault() ?? new Tenant(),
                    Name = "Birmingham City Council",
                    OrganisationType = _organisationTypes?.Where(organisationType => organisationType.Name.Equals("Local Authority"))?.FirstOrDefault() ?? new OrganisationType(),
                    OrganisationContacts = new List<Contact>
                    {
                        new Contact
                        {
                            Name = "Switchboard",
                            Telephone = "0121 303 9944",
                            NextGenerationText = "Dial 18001 before the full national phone number.",
                            WebSite = new Uri("https://www.birmingham.gov.uk/contactus"),
                            Minicom = "0121 303 1119 or 0121 675 8221",
                            AddressLine1 = "Council House",
                            AddressLine2 = "Victoria Square",
                            TownOrCity = "Birmingham",
                            County = "West Midlands",
                            Postcode = "B1 1BB"
                        }
                    }
                },
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
                */
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
