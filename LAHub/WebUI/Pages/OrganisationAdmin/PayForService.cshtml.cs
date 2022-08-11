using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.OrganisationAdmin;

public class PayForServiceModel : PageModel
{
    [BindProperty]
    public string Gender { get; set; } = default!;

    public string[] Genders = new[] { "Male", "Female", "Unspecified" };
    
    [BindProperty]
    public string IsPayedFor { get; set; } = default!;

    [BindProperty]
    public string PayUnit { get; set; } = default!;

    [BindProperty]
    public decimal Cost { get; set; }

    [BindProperty]
    public string? StrOrganisationViewModel { get; set; }

    public void OnGet(string strOrganisationViewModel)
    {
        StrOrganisationViewModel = strOrganisationViewModel;
    }

    public void OnPost()
    {

    }
}
