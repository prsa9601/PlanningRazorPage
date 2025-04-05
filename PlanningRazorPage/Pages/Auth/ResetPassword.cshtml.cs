using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Services.Auth;
using System.ComponentModel.DataAnnotations;

namespace PlanningRazorPage.Pages.Auth
{
    [Authorize]
    public class ResetPasswordModel : BaseRazorPage
    {
        private readonly IAuthService _service;

        public ResetPasswordModel(IAuthService service)
        {
            _service = service;
        }
        [BindProperty]
        [Required(ErrorMessage = "رمز عبور جدید الزامی است")]
        [StringLength(100, ErrorMessage = "رمز عبور باید بین {2} تا {1} کاراکتر باشد",
                 MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "تکرار رمز عبور الزامی است")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "رمز عبور و تکرار آن مطابقت ندارند")]
        public string ConfirmPassword { get; set; }
        public async Task<IActionResult> OnGet(string token, string email)
        {
            var result = await _service.VerificationForgotPassword(new Models.Auth.VerifiedEmailForgotPasswordCommand
            {
                Email = email,
                VerificationEmailToken = token
            });
            if (result!.IsSuccess)
            {
                return Page();
            }
            else
            {
                result.MetaData.Message=("درخواست غیر مجاز!").ToString();
                return RedirectAndShowAlertWithError(result, Redirect("RequestNewPassword"));
            }
        }
    }
}

//if (User.Identity.IsAuthenticated)
//{

//}
//return Redirect("/");