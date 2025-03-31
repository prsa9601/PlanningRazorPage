using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Services.Auth;

namespace PlanningRazorPage.Pages.Auth
{
    public class VerifyEmailModel : BaseRazorPage
    {
        private readonly IAuthService _service;

        public VerifyEmailModel(IAuthService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnGet(string token)
        {
            var result = await _service.VerificationEmail(new Models.Auth.VerificationEmailViewModel
            {
                token = token.ToString(),
            });

            if (result.IsSuccess)
            {
                //IsVerified = true;
                return RedirectAndShowAlert(result, Redirect("../index"));
                //return RedirectAndShowAlert(result, Redirect("VerificationEmail?isVerified=true"));

            }
            return RedirectAndShowAlert(result, RedirectToPage());
        }
        //public async Task<IActionResult> OnPost()
        //{

        //}
    }
}
