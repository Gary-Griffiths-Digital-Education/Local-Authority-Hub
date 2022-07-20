using LAHub.Domain.Entities;
using System.Collections.ObjectModel;


namespace Infrastructure.Persistence.SeedData.Organisations
{
    public class OrganisationSeedData
    {
        private Tenant _tenantUnknown = new("Unknown", "Unknown");
        private OrganisationType _organisationTypeUnknown = new OrganisationType("Unknown", "Unknown");

        private readonly IReadOnlyCollection<Tenant> _tenants = new List<Tenant>
        {
            new Tenant("Bir", "Birmingham City Council" ),
            new Tenant("Bri", "Bristol City Council" ),
            new Tenant("Red", "Redbridge District Council" ),
            new Tenant("Suf", "Suffolk County Council" ),
            new Tenant("TH", "Tower Hamlets Council" ),
        };

        private readonly IReadOnlyCollection<OrganisationType> _organisationTypes = new List<OrganisationType>
        {
            new OrganisationType("Local Authority", "Local Authority"),
            new OrganisationType("Charity", "Charity")
        };

        private readonly List<Classification> _classifications;

        public OrganisationSeedData(List<Classification> classifications)
        {
            _classifications = classifications;
        }

        public IReadOnlyCollection<Organisation> SeedOrganistions()
        {
            var organisations = new List<Organisation>()
            {

                GetBirminghamCityCouncil(),

                new Organisation(
                    _tenants?.Where(tenant => tenant.Name.Equals("Bri"))?.FirstOrDefault() ?? _tenantUnknown,
                    _organisationTypes?.Where(organisationType => organisationType.Name.Equals("Local Authority"))?.FirstOrDefault() ?? _organisationTypeUnknown,
                    "Bristol City Council",
                    "Bristol City Council",
                    null,
                    null,
                    null
                ),
                new Organisation(
                    _tenants?.Where(tenant => tenant.Name.Equals("Red"))?.FirstOrDefault() ?? _tenantUnknown,
                    _organisationTypes?.Where(organisationType => organisationType.Name.Equals("Local Authority"))?.FirstOrDefault() ?? _organisationTypeUnknown,
                    "Redbridge Council",
                    "Redbridge Council",
                    null,
                    null,
                    null
                ),

                GetSuffolkCountyCouncil(),

                new Organisation(
                    _tenants?.Where(tenant => tenant.Name.Equals("TH"))?.FirstOrDefault() ?? _tenantUnknown,
                    _organisationTypes?.Where(organisationType => organisationType.Name.Equals("Local Authority"))?.FirstOrDefault() ?? _organisationTypeUnknown,
                    "Tower Hamlets Council",
                    "Tower Hamlets Council",
                    null,
                    null,
                    null
                ),
            };

            return new ReadOnlyCollection<Organisation>(organisations);
        }

        private void AddServiceClasifications(Service service)
        {
            List<ServiceClassification> serviceClassification = new()
            {
                new ServiceClassification(service.Id, _classifications.ElementAt(0)),
                new ServiceClassification(service.Id, _classifications.ElementAt(1))
            };

            service.ServiceClassifications = serviceClassification;
        }

        private Organisation GetBirminghamCityCouncil()
        {
            Contact contact = new(
                            _tenants?.Where(tenant => tenant.Name.Equals("Bir"))?.FirstOrDefault() ?? _tenantUnknown,
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
                            );

            var birminghamCityCouncil = new Organisation(
                 _tenants?.Where(tenant => tenant.Name.Equals("Bir"))?.FirstOrDefault() ?? _tenantUnknown,
                 _organisationTypes?.Where(organisationType => organisationType.Name.Equals("Local Authority"))?.FirstOrDefault() ?? _organisationTypeUnknown,
                    "Birmingham City Council",
                    "Birmingham City Council",
                    null,
                    null,
                    contact
                );

            var address = new Address("Council House",
                        "Victoria Square",
                        "Birmingham",
                        "B1 1BB"
                        //,
                        //null
                        );

            var location = new LAHub.Domain.Entities.Location("Edgbaston",
            "Council House",
            52.48101394467345, -1.9041462501082664,
            address
            );

            location.Address = address;
            location.AddressId = address.Id;

            Service service = new(
            "Service 1",
            "We supply this service",
            3,
            25,
            "Free",
            "Free",
            "9am to 5pm",
            birminghamCityCouncil,
            contact,
            location
            );

            AddServiceClasifications(service);

            birminghamCityCouncil.Services = new List<Service>() { service };

            return birminghamCityCouncil;
        }

        private Organisation GetSuffolkCountyCouncil()
        {
            var suffolkCountyCouncil = new Organisation(
                _tenants?.Where(tenant => tenant.Name.Equals("Suf"))?.FirstOrDefault() ?? _tenantUnknown,
                _organisationTypes?.Where(organisationType => organisationType.Name.Equals("Local Authority"))?.FirstOrDefault() ?? _organisationTypeUnknown,
                    "Suffolk County Council",
                    "Suffolk County Council",
                    null,
                    null,
                    new Contact(
                            _tenants?.Where(tenant => tenant.Name.Equals("Suf"))?.FirstOrDefault() ?? _tenantUnknown,
                            "Customer Services",
                            "Customer Services",
                            "0345 606 6067",
                            null,
                            null,
                            "customer.services@​​suffolk.gov.uk",
                            new Uri("https://www.suffolk.gov.uk/"),
                            null,
                            null,
                            null,
                            "Endeavour House",
                            "8 Russell Road",
                            "Ipswich",
                            "Suffolk",
                            "IP1 BX",
                            null
                            )
                );

            //Parenta Start
            var parentaAddress = new Address(
                "2-8 London Road",
                "Rocky Hill",
                "Maidstone",
                "Kent"
            //,
            //parentalocation
            );

            var parentalocation = new LAHub.Domain.Entities.Location("Kent",
            "Head Office",
            51.27235015967112, 0.5139561924728728,
            parentaAddress
            );

            Service parenta = new(
            "Parenta",
            "There’s so much to think about when it comes to running a childcare setting. At Parenta, our aim is to provide Early Years practitioners with the tools you need to run your business efficiently, from training qualifications to administration software, fee collection services etc",
            3,
            25,
            "Free",
            "Free",
            "9am to 5pm",
            suffolkCountyCouncil,
            new Contact(
                            _tenants?.Where(tenant => tenant.Name.Equals("Suf"))?.FirstOrDefault() ?? _tenantUnknown,
                            "Customer Services",
                            "Customer Services",
                            "0345 606 6067",
                            null,
                            null,
                            "customer.services@​​suffolk.gov.uk",
                            new Uri("https://www.suffolk.gov.uk/"),
                            null,
                            null,
                            null,
                            "Endeavour House",
                            "8 Russell Road",
                            "Ipswich",
                            "Suffolk",
                            "IP1 BX",
                            null
                            ),
            parentalocation
            );

            AddServiceClasifications(parenta);

            //Parenta End

            //Robins Childcare Start
            var robinsChildCareAddress = new Address(
                "Capel St Mary School Grounds",
                "The Street, Capel St Mary",
                "Ipswich",
                "IP9 2EG"
            //,
            //robinsChildCarelocation
            );

            var robinsChildCarelocation = new LAHub.Domain.Entities.Location("Ipswich",
            "Capel St Mary School Grounds",
            52.00337217140149, 1.0454688472631388,
            robinsChildCareAddress
            );


            Service robinsChildCare = new(
            "Robins Child Care",
            "A purpose built childcare establishment for 3 months to 11 years. Seperate rooms for differing age groups. 2, 3 and 4 year old grant funding available.Full day care and sessional care.",
            3,
            25,
            "Free",
            "Free",
            "9am to 5pm",
            suffolkCountyCouncil,
            new Contact(
                            _tenants?.Where(tenant => tenant.Name.Equals("Suf"))?.FirstOrDefault() ?? _tenantUnknown,
                            "Customer Services",
                            "Customer Services",
                            "0345 606 6067",
                            null,
                            null,
                            "customer.services@​​suffolk.gov.uk",
                            new Uri("https://www.suffolk.gov.uk/"),
                            null,
                            null,
                            null,
                            "Endeavour House",
                            "8 Russell Road",
                            "Ipswich",
                            "Suffolk",
                            "IP1 BX",
                            null
                            ),
            robinsChildCarelocation
            
            );

            AddServiceClasifications(robinsChildCare);
            //Robins Childcare End

            //YMCA Childcare Grundisburgh Start
            var YmcaChildcareGrundisburghAddress = new Address(
                "Alice Driver Road",
                "Grundisburgh",
                "Ipswich",
                "IP13 6XH"
            //,
            //YmcaChildcareGrundisburghlocation
            );

            var YmcaChildcareGrundisburghlocation = new LAHub.Domain.Entities.Location("Ipswich",
            "Alice Driver Road",
            52.10981163510955, 1.2458769562756002,
            YmcaChildcareGrundisburghAddress
            );

            Service YmcaChildcareGrundisburgh = new(
            "YMCA Childcare Grundisburgh",
            "YMCA Childcare Grundisburgh is a 24 place preschool on the grounds on Grundisburgh Primary School. It is a term time only setting, opened 8-3.15 weekdays offering childcare for children aged between 2 and 5 years.",
            3,
            25,
            "Free",
            "Free",
            "9am to 5pm",
            suffolkCountyCouncil,
            new Contact(
                            _tenants?.Where(tenant => tenant.Name.Equals("Suf"))?.FirstOrDefault() ?? _tenantUnknown,
                            "Customer Services",
                            "Customer Services",
                            "0345 606 6067",
                            null,
                            null,
                            "customer.services@​​suffolk.gov.uk",
                            new Uri("https://www.suffolk.gov.uk/"),
                            null,
                            null,
                            null,
                            "Endeavour House",
                            "8 Russell Road",
                            "Ipswich",
                            "Suffolk",
                            "IP1 BX",
                            null
                            ),
            YmcaChildcareGrundisburghlocation
            );

            AddServiceClasifications(YmcaChildcareGrundisburgh);

            //YMCA Childcare Grundisburgh End

            suffolkCountyCouncil.Services = new List<Service>() { parenta, robinsChildCare, YmcaChildcareGrundisburgh };

            return suffolkCountyCouncil;
        }
    }
}
