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
        public IRequestService _service { get; set; }
        public RequestBoxModel(IRequestService service)
        {
            _service = service;
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
