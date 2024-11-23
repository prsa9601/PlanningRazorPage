using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.Package;
using PlanningRazorPage.Services.Package;

namespace PlanningRazorPage.Pages.Admin.Package
{
    public class ListModel : BaseRazorPage
    {
        private readonly IPackageService _service;

        public ListModel(IPackageService service)
        {
            _service = service;
        }
        [BindProperty(SupportsGet = true)]
        public List<PackageDto?> Packages  { get; set; }
        public async void OnGet()
        {
            Packages = await _service.GetListPackages();
        }
    }
}
