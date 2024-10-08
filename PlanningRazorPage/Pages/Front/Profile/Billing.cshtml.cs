using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Services.Package;

namespace PlanningRazorPage.Pages.Front.Profile
{
    public class BillingModel : PageModel
    {
        private readonly IPackageService _service;

        public BillingModel(IPackageService service)
        {
            _service = service;
        }

        public long id { get; set; }
        
        public void OnGet()
        {
        }
        public void OnPost()
        {
        }
    }
}
