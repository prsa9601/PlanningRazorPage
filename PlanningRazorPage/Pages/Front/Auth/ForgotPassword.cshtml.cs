using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Services.Auth;

namespace PlanningRazorPage.Pages.Front.Auth
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly IAuthService _service;

        public ForgotPasswordModel(IAuthService service)
        {
            _service = service;
        }

        public string Password { get; set; }

        public void OnGet()
        {
        }
        public void OnPost()
        {
        }
    }
}
