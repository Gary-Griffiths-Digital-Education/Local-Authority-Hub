using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Models;

namespace WebUI.Pages.OrganisationAdmin;

public class ContactDetailsModel : PageModel
{
    [BindProperty]
    public List<string> ContactSelection { get; set; } = default!;
    [BindProperty]
    public string Email { get; set; } = default!;
    [BindProperty]
    public string Telephone { get; set; } = default!;
    [BindProperty]
    public string Website { get; set; } = default!;

    [BindProperty]
    public string? StrOrganisationViewModel { get; set; }

    public void OnGet(string strOrganisationViewModel)
    {
        StrOrganisationViewModel = strOrganisationViewModel;
    }

    public IActionResult OnPost()
    {
        //if (!ModelState.IsValid)
        //{
        //    return Page();
        //}

        if (!string.IsNullOrEmpty(StrOrganisationViewModel))
        {
            var organisationViewModel = JsonConvert.DeserializeObject<OrganisationViewModel>(StrOrganisationViewModel) ?? new OrganisationViewModel();
            organisationViewModel.Email = Email;
            organisationViewModel.Telephone = Telephone;
            organisationViewModel.Website = Website;

            StrOrganisationViewModel = JsonConvert.SerializeObject(organisationViewModel);
        }

        return RedirectToPage("/OrganisationAdmin/ServiceDescription", new
        {
            strOrganisationViewModel = StrOrganisationViewModel
        });
    }
}
