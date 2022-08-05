using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Models;

namespace WebUI.Pages.OrganisationAdmin
{
    public class WelcomeModel : PageModel
    {
        [BindProperty]
        public OrganisationViewModel OrganisationViewModel { get; set; } = new OrganisationViewModel();
        public string? StrOrganisationViewModel { get; private set; }
        public void OnGet(string strOrganisationViewModel)
        {
            if (strOrganisationViewModel != null)
                OrganisationViewModel = JsonConvert.DeserializeObject<OrganisationViewModel>(strOrganisationViewModel) ?? new OrganisationViewModel();
            
            StrOrganisationViewModel = strOrganisationViewModel;
        }
    }
}
