using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models;
using PlanningRazorPage.Models.User;
using PlanningRazorPage.Services.User;

namespace PlanningRazorPage.Pages.Admin.User
{
    public class DetailModel : BaseRazorPage
    {
        private readonly IUserService _service;

        public DetailModel(IUserService service)
        {
            _service = service;
        }
        public UserDto? user { get; set; }
        public async Task<IActionResult> OnGet(string id)
        {
            user = await _service.GetById(id);
            return Page();
        }
        public async Task<IActionResult> OnPostDelete(string id)
        {
            ApiResult? result = await _service.Delete(id);
            return RedirectAndShowAlert(result!, Redirect("Index"));
        }
    }
}
