using LAHub.Domain;
using LAHub.Domain.OpenReferralEnities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.OrganisationAdmin;

public class ServiceDeliveryTypeModel : PageModel
{
    public Dictionary<int, string> DictServiceDelivery = new();

    public List<string> ServiceDeliverySelection { get; set; } = default!;

    [BindProperty]
    public string? StrOrganisationViewModel { get; private set; }

    public void OnGet(string strOrganisationViewModel)
    {
        StrOrganisationViewModel = strOrganisationViewModel;

        //DictServiceDelivery = ((ServiceDelivery[])Enum.GetValues(typeof(ServiceDelivery))).ToDictionary(k => k.ToString(), v => (int)v);

        var myEnumDescriptions = from ServiceDelivery n in Enum.GetValues(typeof(ServiceDelivery))
                                 select new { Id = (int)n, Name = Utility.GetEnumDescription(n) };

        foreach (var myEnumDescription in myEnumDescriptions)
        {
            if (myEnumDescription.Id == 0)
                continue;
            DictServiceDelivery[myEnumDescription.Id] = myEnumDescription.Name;
        }
    }

}
