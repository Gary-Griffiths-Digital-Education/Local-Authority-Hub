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

                GetBirminghamCityCouncil(),

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

                GetSuffolkCountyCouncil(),

                //new Organisation
                //{
                //    Tenant = new Tenant(),
                //    Name = "Suffolk County Council",
                //    OrganisationType = _organisationTypes?.Where(organisationType => organisationType.Name.Equals("Local Authority"))?.FirstOrDefault() ?? new OrganisationType(),
                //    Services = new List<Service>()
                //    {

                //    }
                    
                //},
                
                new Organisation()
                {
                    Tenant = new Tenant(),
                    Name = "Tower Hamlets Council"
                }
            };

            return new ReadOnlyCollection<Organisation>(organisations);
        }

        private Organisation GetBirminghamCityCouncil()
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

            return birminghamCityCouncil;
        }

        private Organisation GetSuffolkCountyCouncil()
        {
            var suffolkCountyCouncil = new Organisation()
            {
                Tenant = _tenants?.Where(tenant => tenant.Name.Equals("Suf"))?.FirstOrDefault() ?? new Tenant(),
                Name = "Suffolk County Council",
                OrganisationType = _organisationTypes?.Where(organisationType => organisationType.Name.Equals("Local Authority"))?.FirstOrDefault() ?? new OrganisationType(),
                OrganisationContacts = new List<Contact>
                    {
                        new Contact(
                            _tenants?.Where(tenant => tenant.Name.Equals("Suf"))?.FirstOrDefault() ?? new Tenant(),
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

                    }
            };

            //Parenta Start
            Service parenta = new(
            "Parenta",
            "There’s so much to think about when it comes to running a childcare setting. At Parenta, our aim is to provide Early Years practitioners with the tools you need to run your business efficiently, from training qualifications to administration software, fee collection services etc",
            suffolkCountyCouncil
            );


            var parentalocation = new LAHub.Domain.Entities.Location("Kent",
            "Head Office",
            51.27235015967112, 0.5139561924728728
            );

            var parentaAddress = new Address(
                "2-8 London Road",
                "Rocky Hill",
                "Maidstone",
                "Kent",
                parentalocation
            );

            ServiceLocation parentaServiceLocation = new(parenta.Id, parentalocation.Id);
            parentaServiceLocation.Service = parenta;
            parentaServiceLocation.Location = parentalocation;
            parenta.ServiceLocations = new [] { parentaServiceLocation };
            //Parenta End

            //Robins Childcare Start
            Service robinsChildCare = new(
            "Robins Child Care",
            "A purpose built childcare establishment for 3 months to 11 years. Seperate rooms for differing age groups. 2, 3 and 4 year old grant funding available.Full day care and sessional care.",
            suffolkCountyCouncil
            );



            var robinsChildCarelocation = new LAHub.Domain.Entities.Location("Ipswich",
            "Capel St Mary School Grounds",
            52.00337217140149, 1.0454688472631388
            );

            var robinsChildCareAddress = new Address(
                "Capel St Mary School Grounds",
                "The Street, Capel St Mary",
                "Ipswich",
                "IP9 2EG",
                robinsChildCarelocation
            );

            ServiceLocation robinsChildCareServiceLocation = new(robinsChildCare.Id, robinsChildCarelocation.Id);
            robinsChildCareServiceLocation.Service = robinsChildCare;
            robinsChildCareServiceLocation.Location = robinsChildCarelocation;

            robinsChildCare.ServiceLocations = new List<ServiceLocation>
            {
                robinsChildCareServiceLocation
            };
            //Robins Childcare End

            //YMCA Childcare Grundisburgh Start
            Service YmcaChildcareGrundisburgh = new(
            "YMCA Childcare Grundisburgh",
            "YMCA Childcare Grundisburgh is a 24 place preschool on the grounds on Grundisburgh Primary School. It is a term time only setting, opened 8-3.15 weekdays offering childcare for children aged between 2 and 5 years.",
            suffolkCountyCouncil
            );

            var YmcaChildcareGrundisburghlocation = new LAHub.Domain.Entities.Location("Ipswich",
            "Alice Driver Road",
            52.10981163510955, 1.2458769562756002
            );

            var YmcaChildcareGrundisburghAddress = new Address(
                "Alice Driver Road",
                "Grundisburgh",
                "Ipswich",
                "IP13 6XH",
                YmcaChildcareGrundisburghlocation
            );

            ServiceLocation YmcaChildcareGrundisburghServiceLocation = new(YmcaChildcareGrundisburgh.Id, YmcaChildcareGrundisburghlocation.Id);
            YmcaChildcareGrundisburghServiceLocation.Service = YmcaChildcareGrundisburgh;
            YmcaChildcareGrundisburghServiceLocation.Location = YmcaChildcareGrundisburghlocation;

            YmcaChildcareGrundisburgh.ServiceLocations = new List<ServiceLocation>
            {
                YmcaChildcareGrundisburghServiceLocation
            };
            //YMCA Childcare Grundisburgh End

            suffolkCountyCouncil.Services = new List<Service>() { parenta, robinsChildCare, YmcaChildcareGrundisburgh };

            return suffolkCountyCouncil;
        }
    }
}
