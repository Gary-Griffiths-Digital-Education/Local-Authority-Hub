using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebUI.Services.Api;
using System.Linq;
using Application.Commands.ListOrganisation;

namespace WebUI.Pages.OrganisationAdmin
{
    public class ListOrganisationsModel : PageModel
    {
        private readonly IOrganisationAdminClientService _organisationAdminClientService;
        public ListOrganisationsModel(IOrganisationAdminClientService organisationAdminClientService)
        {
            _organisationAdminClientService = organisationAdminClientService;
        }
        public List<SelectListItem> TenantSelectionList { get; private set; } = new List<SelectListItem>();

        [BindProperty]
        public string SelectedTenant { get; set; } = default!;

        public List<SelectListItem> OrganisationTypeList { get; private set; } = new List<SelectListItem>();

        [BindProperty]
        public string SelectedOrganisationType { get; set; } = default!;
        public List<OrganisationRecord> Organisations { get; private set; } = default!;

        public async Task OnGet()
        {
            await PopulateLists();
        }

        public async Task OnPostButton1()
        {
            Guid? selectedOrganisationType = null;
            if (SelectedOrganisationType != null && SelectedOrganisationType != "All")
            {
                selectedOrganisationType = new Guid(SelectedOrganisationType);
            }
            Organisations = await _organisationAdminClientService.GetOrganisations(new Guid(SelectedTenant), selectedOrganisationType);

            await PopulateLists();
        }

        public IActionResult OnPostButton2()
        {
            Guid? idGuid = null;
            Guid? selectedOrganisationType = null;
            if (SelectedOrganisationType != null && SelectedOrganisationType != "All")
            {
                selectedOrganisationType = new Guid(SelectedOrganisationType);
            }

            Guid? selectedTenant = new Guid(SelectedTenant);

            return RedirectToPage("/OrganisationAdmin/OrganisationDetail", new
            {
                id = idGuid,
                tenantId = selectedTenant,
                organisationTypeId = selectedOrganisationType
            });
        }

        private async Task PopulateLists()
        {
            var tenantList = await _organisationAdminClientService.GetTenantList();
            if (tenantList != null)
            {
                TenantSelectionList = tenantList.Select(tenant => new SelectListItem
                {
                    Text = (tenant.Description != null) ? tenant.Description : tenant.Name,
                    Value = tenant.Id.ToString()
                }).ToList();
            }

            var organisationTypeList = await _organisationAdminClientService.GetOrganisationTypeList();
            if (organisationTypeList != null)
            {
                OrganisationTypeList = organisationTypeList.Select(orgType => new SelectListItem
                {
                    Text = orgType.Name,
                    Value = orgType.Id.ToString()
                }).ToList();

            }

            OrganisationTypeList.Insert(0, new SelectListItem
            {
                Text = "All",
                Value = "All"
            });

        }
    }
}
