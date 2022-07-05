using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Models;
using WebUI.Services.Api;

namespace WebUI.Pages
{
    public class FindServiceFromPostcodeModel : PageModel
    {
        private readonly IPostcodeLocationClientService _postcodeLocationClientService;
        public string Postcode { get; set; } = default!;

        public FindServiceFromPostcodeModel(IPostcodeLocationClientService postcodeLocationClientService)
        {
            _postcodeLocationClientService = postcodeLocationClientService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var postCode = Request.Form["Postcode"];

            if (string.IsNullOrEmpty(postCode))
            {
                return new RedirectToPageResult("/FindServiceFromPostcode");
            }

            PostcodeApiModel postcodeApiModel = await _postcodeLocationClientService.LookupPostcode(postCode);

            var lat = postcodeApiModel.result.latitude;
            var lng = postcodeApiModel.result.longitude;

            return new RedirectToPageResult("/SearchResults");
        }
    }
}
