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
                new Organisation
                (
                    // Birmingham City Council

                    /* tenant               */  _tenants?.Where(tenant => tenant.Name.Equals("Bir"))?.FirstOrDefault() ?? new Tenant(),
                    /* organisationType     */  _organisationTypes?.Where(organisationType => organisationType.Name.Equals("Local Authority"))?.FirstOrDefault() ?? new OrganisationType(),
                    /* name                 */  "Birmingham City Council",
                    /* description          */  string.Empty,
                    /* organisationContacts */  new List<Contact>
                                                {
                                                    new Contact
                                                    (
                                                        /* tenant               */  _tenants?.Where(tenant => tenant.Name.Equals("Bir"))?.FirstOrDefault() ?? new Tenant(),
                                                        /* name                 */  "Switchboard",
                                                        /* description          */  "Switchboard",
                                                        /* telephone            */  "0121 303 9944",
                                                        /* next generation text */  "Dial 18001 before the full national phone number.",
                                                        /* whatsApp             */  string.Empty,
                                                        /* email                */  string.Empty,
                                                        /* website              */  new Uri("https://www.birmingham.gov.uk/contactus"),
                                                        /* facebook             */  default!,
                                                        /* twitter              */  default!,
                                                        /* forum                */  default!,
                                                        /* addressLine1         */  "Council House",
                                                        /* addressLine2         */  "Victoria Square",
                                                        /* townOrCity           */  "Birmingham",
                                                        /* county               */  "West Midlands",
                                                        /* postcode             */  "B1 1BB",
                                                        /* minicom              */  "0121 303 1119 or 0121 675 8221",
                                                        /* latitude             */  default!,
                                                        /* longitude            */  default!
                                                    )
                                                },
                    /* organisationServices */  new List<Service>
                                                {
                                                    new Service
                                                    (
                                                        /* tenant               */ _tenants?.Where(tenant => tenant.Name.Equals("Bir"))?.FirstOrDefault() ?? new Tenant(),
                                                        /* name                 */  "Service 1 name",
                                                        /* description          */  "Service 1 description",
                                                        /* serviceCategories    */  
                                                                                    new Category
                                                                                    (
                                                                                        /* name         */  "Adults",
                                                                                        /* description  */  string.Empty
                                                                                    ),
                                                        /* serviceContacts      */  new List<Contact>
                                                                                    {
                                                                                        new Contact
                                                                                        (
                                                                                            /* tenant               */  _tenants?.Where(tenant => tenant.Name.Equals("Bir"))?.FirstOrDefault() ?? new Tenant(),
                                                                                            /* name                 */  "Contact 1 name",
                                                                                            /* description          */  "Contact 1 description",
                                                                                            /* telephone            */  "Contact 1 telephone",
                                                                                            /* next generation text */  "Contact 1 next generation text",
                                                                                            /* whatsApp             */  "Contact 1 whatsapp",
                                                                                            /* email                */  "Contact 1 email",
                                                                                            /* website              */  new Uri("https://www.birmingham.gov.uk/contactus"),
                                                                                            /* facebook             */  default!,
                                                                                            /* twitter              */  default!,
                                                                                            /* forum                */  default!,
                                                                                            /* addressLine1         */  "Contact 1 address line 1",
                                                                                            /* addressLine2         */  "Contact 1 address line 2",
                                                                                            /* townOrCity           */  "Contact 1 town or city",
                                                                                            /* county               */  "Contact 1 county",
                                                                                            /* postcode             */  "Contact 1 postcode",
                                                                                            /* minicom              */  "Contact 1 minicom",
                                                                                            /* latitude             */  default!,
                                                                                            /* longitude            */  default!
                                                                                        )
                                                                                    },
                                                        /* organisation         */  default!
                                                    ),
                                                  new Service
                                                    (
                                                        /* tenant               */ _tenants?.Where(tenant => tenant.Name.Equals("Bir"))?.FirstOrDefault() ?? new Tenant(),
                                                        /* name                 */  "Service 2 name",
                                                        /* description          */  "Service 2 description",
                                                        /* serviceCategories    */  
                                                                                    new Category
                                                                                    (
                                                                                        /* name         */  "Children",
                                                                                        /* description  */  string.Empty
                                                                                    ),
                                                        /* serviceContacts      */  new List<Contact>
                                                                                    {
                                                                                        new Contact
                                                                                        (
                                                                                            /* tenant               */  _tenants?.Where(tenant => tenant.Name.Equals("Bir"))?.FirstOrDefault() ?? new Tenant(),
                                                                                            /* name                 */  "Contact 2 name",
                                                                                            /* description          */  "Contact 2 description",
                                                                                            /* telephone            */  "Contact 2 telephone",
                                                                                            /* next generation text */  "Contact 2 next generation text",
                                                                                            /* whatsApp             */  "Contact 2 whatsapp",
                                                                                            /* email                */  "Contact 2 email",
                                                                                            /* website              */  new Uri("https://www.birmingham.gov.uk/contactus"),
                                                                                            /* facebook             */  default!,
                                                                                            /* twitter              */  default!,
                                                                                            /* forum                */  default!,
                                                                                            /* addressLine1         */  "Contact 2 address line 1",
                                                                                            /* addressLine2         */  "Contact 2 address line 2",
                                                                                            /* townOrCity           */  "Contact 2 town or city",
                                                                                            /* county               */  "Contact 2 county",
                                                                                            /* postcode             */  "Contact 2 postcode",
                                                                                            /* minicom              */  "Contact 2 minicom",
                                                                                            /* latitude             */  default!,
                                                                                            /* longitude            */  default!
                                                                                        )
                                                                                    },
                                                        /* organisation         */  default!
                                                    )
                                                }
                /* parentOrganisation   */, default!

                )
            };

            //Service service = new(
            //"Service 1",
            //"We supply this service",
            //birminghamCityCouncil
            //);

            //birminghamCityCouncil.Services = new List<Service>() { service };

            //var location = new LAHub.Domain.Entities.Location("Edgbaston",
            //"Council House",
            //52.48101394467345, -1.9041462501082664
            //);

            return new ReadOnlyCollection<Organisation>(organisations);
        }
    }
}
