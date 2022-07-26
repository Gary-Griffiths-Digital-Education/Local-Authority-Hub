//using Application.Commands.ListOrganisationType;
//using Application.Models.DtoEntities;
//using AutoMapper;
//using LAHub.Domain.Entities;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using WebUI.Services.Api;

//namespace WebUI.Pages.OrganisationAdmin;

//public class OrganisationDetailModel : PageModel
//{
//    private readonly IOrganisationAdminClientService _organisationAdminClientService;
//    private readonly IMapper _mapper;

//    private List<OrganisationTypeRecord> _organisationTypeRecords = new List<OrganisationTypeRecord>();

//    public List<SelectListItem> OrganisationTypeList { get; private set; } = new List<SelectListItem>();

//    [BindProperty]
//    public string SelectedOrganisationType { get; set; } = default!;


//    [BindProperty]
//    public OrganisationDto Organisation { get; set; } = default!;
//    public OrganisationDetailModel(IOrganisationAdminClientService organisationAdminClientService, IMapper mapper)
//    {
//        _organisationAdminClientService = organisationAdminClientService;
//        _mapper = mapper;
//    }
//    public async Task OnGet(Guid? id, Guid? tenantId, Guid? organisationTypeId)
//    {
//        if (id != null)
//        {
//            var organisation = await _organisationAdminClientService.GetOrganisationById(id.Value);
//            Organisation = _mapper.Map<OrganisationDto>(organisation);
//        }   
//        else
//        {
//            var tenant = await GetTenantById(tenantId);
//            TenantDto tenantDto = _mapper.Map<TenantDto>(tenant);
//            var organisationType = await GetOrganisationTypeById(organisationTypeId);
//            OrganisationTypeDto organisationTypeDto = _mapper.Map<OrganisationTypeDto>(organisationType);
//            /*
//            Organisation = new(
//                tenantDto,
//                organisationTypeDto,
//                "New Organisation",
//                null,
//                null,
//                null,
//                new ContactDto(tenantDto,"New Contact",
//                            null,
//                            null,
//                            null,
//                            null,
//                            null,
//                            null,
//                            null,
//                            null,
//                            null,
//                            null,
//                            null,
//                            null,
//                            null,
//                            null,
//                            null)
//            );
//            */
//            Organisation = new(
//                tenantDto,
//                organisationTypeDto,
//                "New Organisation",
//                "Description",
//                "Logo Url",
//                "Logo Alt Test",
//                new ContactDto(tenantDto, "New Contact",
//                            null,
//                            null,
//                            null,
//                            null,
//                            null,
//                            null,
//                            null,
//                            null,
//                            null,
//                            null,
//                            null,
//                            null,
//                            null,
//                            null,
//                            null)
//            );

//            //So we know it is a new one
//            Organisation.Id = Guid.Empty;
//        }

//        await PopulateOrganisationTypeList(Organisation?.OrganisationType?.Name);
//    }

//    public async Task<IActionResult> OnPost()
//    {
//        var tenant = await GetTenantById(Organisation.Tenant.Id);
//        Organisation.Tenant = _mapper.Map<TenantDto>(tenant);
//        var organisationType = await GetOrganisationTypeById(Organisation.OrganisationType.Id);
//        Organisation.OrganisationType = _mapper.Map<OrganisationTypeDto>(organisationType);

//        Guid retVal;

//        if (Organisation.Id == Guid.Empty)
//        {
//            var organisation = _mapper.Map<Organisation>(Organisation);
//            retVal = await _organisationAdminClientService.CreateOrganisation(
//                organisation.Tenant,
//                organisation.Name,
//                organisation.Description,
//                organisation.LogoUrl,
//                organisation.LogoAltText,
//                organisation.OrganisationType,
//                organisation.Contact,
//                new List<Service>()
//                );
//        }
//        else
//        {
//            var orginalOrganisation = await _organisationAdminClientService.GetOrganisationById(Organisation.Id);
//            var organisation = _mapper.Map<Organisation>(Organisation);
//            organisation.Id = Organisation.Id;
//            retVal = await _organisationAdminClientService.UpdateOrganisation(
//                organisation.Id,
//                organisation.Tenant,
//                organisation.Name,
//                organisation.Description,
//                organisation.LogoUrl,
//                organisation.LogoAltText,
//                organisation.OrganisationType,
//                orginalOrganisation.Contact,
//                orginalOrganisation.Services);
//        }

//        return RedirectToPage("/OrganisationAdmin/CheckOrganisationDetailAnswers", new
//        {
//            retVal
//        });

//        //await PopulateOrganisationTypeList(Organisation?.OrganisationType?.Name);
//    }

//    private async Task<Tenant> GetTenantById(Guid? tenantId)
//    {
//        var tenantList = await _organisationAdminClientService.GetTenantList();
//        var tenantRecord = tenantList.FirstOrDefault(x => x.Id == tenantId);
//        if (tenantRecord == null)
//            throw new ArgumentNullException(nameof(tenantRecord));
//        return new Tenant(tenantRecord.Name, tenantRecord.Description)
//        {
//            Id = tenantRecord.Id
//        };
//    }

//    private async Task<OrganisationType> GetOrganisationTypeById(Guid? organisationTypeId)
//    {
//        OrganisationType organisationType = new("Unknown", "Unknown");
//        if (!_organisationTypeRecords.Any())
//        {
//            _organisationTypeRecords = await _organisationAdminClientService.GetOrganisationTypeList();
//        }
//        if (_organisationTypeRecords != null)
//        {
//            if (organisationTypeId != null)
//            {
//                var selectedOrganisationTypeRecord = _organisationTypeRecords.FirstOrDefault(x => x.Id == organisationTypeId);
//                if (selectedOrganisationTypeRecord is not null)
//                {
//                    organisationType = new(selectedOrganisationTypeRecord.Name, selectedOrganisationTypeRecord.Description)
//                    {
//                        Id = selectedOrganisationTypeRecord.Id
//                    };
//                }

//            }
//            else
//            {
//                var selectedOrganisationTypeRecord = _organisationTypeRecords.FirstOrDefault();
//                if (selectedOrganisationTypeRecord is not null)
//                {
//                    organisationType = new(selectedOrganisationTypeRecord.Name, selectedOrganisationTypeRecord.Description)
//                    {
//                        Id = selectedOrganisationTypeRecord.Id
//                    };
//                }

//            }
//        }

//        return organisationType;
//    }

//    private async Task PopulateOrganisationTypeList(string? selectedItem)
//    {

//        if (!_organisationTypeRecords.Any())
//        {
//            _organisationTypeRecords = await _organisationAdminClientService.GetOrganisationTypeList();
//        }
       
//        if (_organisationTypeRecords != null)
//        {
//            OrganisationTypeList = _organisationTypeRecords.Select(orgType => new SelectListItem
//            {
//                Text = orgType.Name,
//                Value = orgType.Id.ToString()
//            }).ToList();

//        }

//        if (!string.IsNullOrEmpty(selectedItem))
//        {
//            SelectedOrganisationType = selectedItem;
//        }
//    }
//}
