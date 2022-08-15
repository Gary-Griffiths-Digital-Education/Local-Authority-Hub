using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Models;

namespace WebUI.Pages.OrganisationAdmin;

public class InPersonWhereModel : PageModel
{
    [BindProperty]
    public string Address_1 { get; set; } = default!;
    [BindProperty]
    public string City { get; set; } = default!;
    [BindProperty]
    public string Postal_code { get; set; } = default!;
    [BindProperty]
    public string Country { get; set; } = default!;
    [BindProperty]
    public string State_province { get; set; } = default!;

    [BindProperty]
    public List<string> InPersonSelection { get; set; } = default!;

    [BindProperty]
    public OrganisationViewModel OrganisationViewModel { get; set; } = new OrganisationViewModel();

    [BindProperty]
    public string? StrOrganisationViewModel { get; set; }

    public void OnGet(string strOrganisationViewModel)
    {
        StrOrganisationViewModel = strOrganisationViewModel;
        if (!string.IsNullOrEmpty(strOrganisationViewModel))
            OrganisationViewModel = JsonConvert.DeserializeObject<OrganisationViewModel>(StrOrganisationViewModel) ?? new OrganisationViewModel();

        OrganisationViewModel.Country = "England";
    }

    public IActionResult OnPost()
    {
        if (InPersonSelection.Contains("Our own location"))
        {
            ModelState.Remove("Country");
            Country = "England";
            if (!ModelState.IsValid)
            {
                return Page();
            }
        }

        if (!InPersonSelection.Any())
        {
            return Page();
        }
        

        if (!string.IsNullOrEmpty(StrOrganisationViewModel))
        {
            OrganisationViewModel = JsonConvert.DeserializeObject<OrganisationViewModel>(StrOrganisationViewModel) ?? new OrganisationViewModel();
            OrganisationViewModel.InPersonSelection = new List<string>(InPersonSelection);
            OrganisationViewModel.Address_1 = Address_1;
            OrganisationViewModel.City = City;
            OrganisationViewModel.State_province = State_province;
            OrganisationViewModel.Country = "England";
            OrganisationViewModel.Postal_code = Postal_code;

            StrOrganisationViewModel = JsonConvert.SerializeObject(OrganisationViewModel);
        }

        return RedirectToPage("/OrganisationAdmin/WhoFor", new
        {
            strOrganisationViewModel = StrOrganisationViewModel
        });


    }
}
