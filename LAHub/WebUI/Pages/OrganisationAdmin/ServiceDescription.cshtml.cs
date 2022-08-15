using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Models;

namespace WebUI.Pages.OrganisationAdmin;

public class ServiceDescriptionModel : PageModel
{
    [BindProperty]
    public string Description { get; set; } = default!;

    [BindProperty]
    public string? StrOrganisationViewModel { get; set; }

    public void OnGet(string strOrganisationViewModel)
    {
        StrOrganisationViewModel = strOrganisationViewModel;
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (!string.IsNullOrEmpty(StrOrganisationViewModel))
        {
            var organisationViewModel = JsonConvert.DeserializeObject<OrganisationViewModel>(StrOrganisationViewModel) ?? new OrganisationViewModel();
            organisationViewModel.ServiceDescription = Description;
 
            StrOrganisationViewModel = JsonConvert.SerializeObject(organisationViewModel);
        }

        return RedirectToPage("/OrganisationAdmin/CheckServiceDetails", new
        {
            strOrganisationViewModel = StrOrganisationViewModel
        });
    }
}
