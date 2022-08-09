using LAHub.Domain.RecordEntities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Services.Api;

namespace WebUI.Pages
{
    public class LocalOfferDetailModel : PageModel
    {
        private readonly ILocalOfferClientService _localOfferClientService;

        public OpenReferralServiceRecord LocalOffer { get; set; } = default!;

        public LocalOfferDetailModel(ILocalOfferClientService localOfferClientService)
        {
            _localOfferClientService = localOfferClientService;
        }   

        public async Task OnGetAsync(string id)
        {
            LocalOffer = await _localOfferClientService.GetLocalOfferById(id);
        }
    }
}
