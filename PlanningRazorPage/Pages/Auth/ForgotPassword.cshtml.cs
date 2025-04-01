using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Services.Auth;

namespace PlanningRazorPage.Pages.Auth
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly IAuthService _service;

        public ForgotPasswordModel(IAuthService service)
        {
            _service = service;
        }

        public string Password { get; set; }

        public IActionResult OnGet()
        {
            //TempData["RedirectLink"] = "front/auth/login";
            //TempData["ErrorNotFound"] = "کاربر مورد نظر";
            //return Redirect("~/errors/NotFound");
            return Page();
        }
        public void OnPost()
        {
        }
    }
}
