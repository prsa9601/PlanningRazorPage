using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Services.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PlanningRazorPage.Pages.Admin.Role
{
    public class DeleteModel : BaseRazorPage
    {
        private readonly IRoleService _service;

        public DeleteModel(IRoleService service)
        {
            _service = service;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostDeleteRole(long roleId)
        {
            return await AjaxTryCatch(() => { return _service.DeleteRole(roleId); });
            //var result =  _service.DeleteProduct(productId);
            //return RedirectToPage("Products");
            //return RedirectToAction("OnGet","Products");
        }
    }
}
