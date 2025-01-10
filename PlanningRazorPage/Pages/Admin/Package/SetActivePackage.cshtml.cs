using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.Package;
using PlanningRazorPage.Services.Package;

namespace PlanningRazorPage.Pages.Admin.Package
{
    public class SetPackageModel : BaseRazorPage
    {
        private readonly IPackageService _service;

        public SetPackageModel(IPackageService service)
        {
            _service = service;
        }

        public void OnGet()
        {
        }
        public void OnPost()
        {
        }
        public async Task<IActionResult> OnPostSetActive(long packageId)
        {
            //return await AjaxTryCatch(() =>
            //{
            //    return _service.SetActivePackage(new SetActivePackageCommand()
            //    {
            //        Id = packageId
            //    });
            //});
            var result = await _service.SetActivePackage(new SetActivePackageCommand()
            {
                Id = packageId
            });
            return RedirectAndShowAlert(result, Redirect("List"));

            //var result = await _service.SetActivePackage(new SetActivePackageCommand()
            //{
            //    Id = id
            //});
            //return Page();
        }
        public async Task<IActionResult> OnPostRemoveActive(long packageId)
        {
            //return await AjaxTryCatch(() => { return _service.RemoveActivePackage(new RemoveActivePackageCommand()
            //{
            //    Id = packageId
            //}); },true,true);
            var result = await _service.RemoveActivePackage(new RemoveActivePackageCommand()
            {
                Id = packageId
            });
            return RedirectAndShowAlert(result, Redirect("List"));


            //var result = await _service.SetActivePackage(new SetActivePackageCommand()
            //{
            //    Id = id
            //});
            //return Page();
        }
    }
}
