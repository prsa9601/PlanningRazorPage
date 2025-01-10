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
        public List<PackageDto?> Packages { get; set; } = new List<PackageDto?>();
        public async Task<IActionResult> OnGet()
        {
            await Task.Delay(2000);
            Packages = await _service.GetListPackages();
            return Page();
        }

        public void OnPost()
        {
        }
        public async Task<IActionResult> OnPostSetActive(long packageId)
        {
            return await AjaxTryCatch(() =>
            {
                return _service.SetActivePackage(new SetActivePackageCommand()
                {
                    Id = packageId
                });
            });
            //var result = await _service.SetActivePackage(new SetActivePackageCommand()
            //{
            //    Id = packageId
            //});
            //return RedirectAndShowAlert(result, Redirect("List"));
        }
        public async Task<IActionResult> OnPostRemoveActive(long packageId)
        {
            return await AjaxTryCatch(() =>
            {
                return _service.RemoveActivePackage(new RemoveActivePackageCommand()
                {
                    Id = packageId
                });
            }, true, true);
         
        }
        public async Task<IActionResult> OnPostDeletePackage(long packageId)
        {
            return await AjaxTryCatch(() =>
            {
                return _service.Delete(packageId);
            }, true, true);
        
        }
    }
}
