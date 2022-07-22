using Application.Common.Models;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebUI.Services.Api;

namespace WebUI.Pages
{
    public class LocalOfferResultsModel : PageModel
    {
        private readonly ILocalOfferClientService _localOfferClientService;

        public double CurrentLatitude { get; set; }
        public double CurrentLongitude { get; set; }

        public PaginatedList<ServiceItem> SearchResults { get; set; } = default!;

        public string SelectedDistance { get; set; } = "212892";

        public List<SelectListItem> DistanceSelectionList { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1609.34", Text = "1 mile" },
            new SelectListItem { Value = "3218.69", Text = "2 miles" },
            new SelectListItem { Value = "8046.72", Text = "5 miles" },
            new SelectListItem { Value = "16093.4", Text = "10 miles" },
            new SelectListItem { Value = "24140.2", Text = "15 miles" },
            new SelectListItem { Value = "32186.9", Text = "20 miles" },
        };

        public LocalOfferResultsModel(ILocalOfferClientService localOfferClientService)
        {
            _localOfferClientService = localOfferClientService;
        }

        public async Task OnGetAsync(double latitude, double longitude, double distance)
        {
            CurrentLatitude = latitude;
            CurrentLongitude = longitude;
            SelectedDistance = distance.ToString();
            SearchResults = await _localOfferClientService.GetLocalOffers(latitude, longitude, distance);
        }

        public IActionResult OnPost()
        {
            SelectedDistance = Request.Form["SelectedDistance"];
            if (double.TryParse(Request.Form["CurrentLatitude"], out double currentLatitude))
            {
                CurrentLatitude = currentLatitude;
            }
            if (double.TryParse(Request.Form["CurrentLongitude"], out double currentLongitude))
            {
                CurrentLongitude = currentLongitude;
            }

            return RedirectToPage("LocalOfferResults", new
            {
                latitude = CurrentLatitude,
                longitude = CurrentLongitude,
                distance = SelectedDistance
            });

        }
    }
}
