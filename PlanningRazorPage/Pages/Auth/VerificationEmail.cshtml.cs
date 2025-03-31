using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Services.Auth;
using PlanningRazorPage.Services.User;

namespace PlanningRazorPage.Pages.Auth
{
    public class VerificationEmailModel : BaseRazorPage
    {
        private readonly IAuthService _service;
        private readonly IUserService _userService;

        public VerificationEmailModel(IAuthService service, IUserService userService)
        {
            _service = service;
            _userService = userService;
        }
        public bool IsVerified { get; set; }
        public async Task<IActionResult> OnGet(bool isVerified)
        {
            var user = await _userService.GetByCurrentUser();
            IsVerified = user.EmailConfirmed;
            return Page();
        }
        public async Task<IActionResult> OnGetResend()
        {
            var result = await _service.SendTokenForVerificationEmail();
            return RedirectAndShowAlert(result, Page());
        }
      
    }
}