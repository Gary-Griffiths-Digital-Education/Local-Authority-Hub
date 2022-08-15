using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Models;

namespace WebUI.Pages.OrganisationAdmin;

public class PayForServiceModel : PageModel
{
    
    
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

    public IActionResult OnPost()
    {
        //if (!ModelState.IsValid)
        //{
        //    return Page();
        //}

        if (!string.IsNullOrEmpty(StrOrganisationViewModel))
        {
            var organisationViewModel = JsonConvert.DeserializeObject<OrganisationViewModel>(StrOrganisationViewModel) ?? new OrganisationViewModel();
            organisationViewModel.IsPayedFor = IsPayedFor;
            organisationViewModel.PayUnit = PayUnit;    
            organisationViewModel.Cost = Cost;

            StrOrganisationViewModel = JsonConvert.SerializeObject(organisationViewModel);
        }

        return RedirectToPage("/OrganisationAdmin/ContactDetails", new
        {
            strOrganisationViewModel = StrOrganisationViewModel
        });
    }
}
