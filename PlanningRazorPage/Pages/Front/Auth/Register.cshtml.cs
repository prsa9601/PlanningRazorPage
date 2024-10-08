using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.Auth;
using PlanningRazorPage.Services.Auth;

namespace PlanningRazorPage.Pages.Front.Auth
{
    public class RegisterModel : BaseRazorPage
    {
        private readonly IAuthService _service;

        public RegisterCommand registerCommand { get; set; }
        public RegisterModel(IAuthService service)
        {
            _service = service;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            var result = await _service.Register(registerCommand);
            return RedirectAndShowAlert(result, Redirect("Index"));
        }
    }
}
