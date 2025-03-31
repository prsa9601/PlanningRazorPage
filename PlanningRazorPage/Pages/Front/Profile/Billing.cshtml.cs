using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.Package;
using PlanningRazorPage.Services.Package;

namespace PlanningRazorPage.Pages.Front.Profile
{
    public class BillingModel : BaseRazorPage
    {
        private readonly IPackageService _service;

        public BillingModel(IPackageService service)
        {
            _service = service;
        }

        public long id { get; set; }
        public PackageDto? package { get; set; }
        public async void OnGet()
        {
            var user = await _service.GetListActiveForCurrentUser();
        }
        public void OnPost()
        {
        }
    }
}
