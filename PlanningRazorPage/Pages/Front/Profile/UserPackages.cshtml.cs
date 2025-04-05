using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.Package;
using PlanningRazorPage.Services.Package;
using PlanningRazorPage.Services.User.UserPackage;
using System.Linq.Expressions;

namespace PlanningRazorPage.Pages.Front.Profile
{
    public class BillingModel : BaseRazorPage
    {
        private readonly IPackageService _service;
        private readonly IUserPackageService _userPackageService;

        public BillingModel(IPackageService service, IUserPackageService userPackageService)
        {
            _service = service;
            _userPackageService = userPackageService;
        }

        public long id { get; set; }
        public List<PackageDtoForUserProfile?> packages { get; set; }
        public async Task<IActionResult> OnGet()
        {
            packages = await _service.GetListActiveForCurrentUser();
            return Page();
        }
        public async Task<IActionResult> OnGetDetails(long id)
        {
            var package = await _userPackageService.GetUserPackageByUserPackageId(id);
            return new JsonResult(package);
        }
        public void OnPost()
        {
        }
        
    }
}
