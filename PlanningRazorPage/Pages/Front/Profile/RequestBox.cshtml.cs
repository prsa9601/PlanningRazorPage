using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Infrastructure.Utils.Decryption;
using PlanningRazorPage.Models.Request;
using PlanningRazorPage.Services.Request;

namespace PlanningRazorPage.Pages.Front.Profile
{
    public class RequestBoxModel : BaseRazorFilter<RequestBoxFilterParam>
    {
        private readonly DecryptionService _decryptionService;
        public IRequestService _service { get; set; }
        public RequestBoxModel(IRequestService service, DecryptionService decryptionService)
        {
            _service = service;
            _decryptionService = decryptionService;
        }

        [BindProperty(SupportsGet = true)]
        public RequestBoxFilterResult? requestBox { get; set; }
     
        public async Task<IActionResult> OnGet()
        {
            requestBox = await _service.GetRequestByFilter(FilterParams);
            return Page();
        }
 
      
    }
}
