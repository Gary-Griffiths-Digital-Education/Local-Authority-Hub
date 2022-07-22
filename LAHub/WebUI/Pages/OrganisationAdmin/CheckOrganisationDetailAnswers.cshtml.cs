using Application.Models.DtoEntities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Services.Api;

namespace WebUI.Pages.OrganisationAdmin
{
    public class CheckOrganisationDetailAnswersModel : PageModel
    {
        private readonly IOrganisationAdminClientService _organisationAdminClientService;
        private readonly IMapper _mapper;

        [BindProperty]
        public OrganisationDto Organisation { get; set; } = default!;

        public CheckOrganisationDetailAnswersModel(IOrganisationAdminClientService organisationAdminClientService, IMapper mapper)
        {
            _organisationAdminClientService = organisationAdminClientService;
            _mapper = mapper;
        }

        public async Task OnGetAsync(Guid? id)
        {
            ArgumentNullException.ThrowIfNull(id, nameof(id));
            var organisation = await _organisationAdminClientService.GetOrganisationById(id.Value);
            Organisation = _mapper.Map<OrganisationDto>(organisation);
        }
    }
}
