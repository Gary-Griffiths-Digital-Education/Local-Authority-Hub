using LAHub.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Services.Api;

namespace WebUI.Pages
{
    public class LocalOfferDetailModel : PageModel
    {
        private readonly ILocalOfferClientService _localOfferClientService;

        public Service LocalOffer { get; set; } = default!;

        public LocalOfferDetailModel(ILocalOfferClientService localOfferClientService)
        {
            _localOfferClientService = localOfferClientService;
        }   

        public async Task OnGetAsync(Guid id)
        {
            LocalOffer = await _localOfferClientService.GetLocalOfferById(id);
        }
    }
}
