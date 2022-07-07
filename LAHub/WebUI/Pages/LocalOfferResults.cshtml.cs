using Application.Common.Models;
using Application.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Services.Api;

namespace WebUI.Pages
{
    public class LocalOfferResultsModel : PageModel
    {
        private readonly ILocalOfferClientService _localOfferClientService;

        public PaginatedList<ServiceItem> SearchResult { get; set; } = default!;

        public LocalOfferResultsModel(ILocalOfferClientService localOfferClientService)
        {
            _localOfferClientService = localOfferClientService;
        }

        public async Task OnGet(double latitude, double longitude)
        {
            //var retVal = await _localOfferClientService.GetTestCommand(latitude, longitude, 212892);
            SearchResult = await _localOfferClientService.GetLocalOffers(latitude, longitude, 212892);
        }
    }
}
