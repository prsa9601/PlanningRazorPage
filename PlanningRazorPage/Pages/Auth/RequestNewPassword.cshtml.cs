using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Services.Auth;

namespace PlanningRazorPage.Pages.Auth
{
    public class RequestNewPasswordModel : PageModel
    {
        private readonly IAuthService _service;

        public RequestNewPasswordModel(IAuthService service)
        {
            _service = service;
        }

        public void OnGet()
        {
        }
        public class EmailRequest
        {
            public string Email { get; set; }
        }

        public async Task<IActionResult> OnPostSend([FromForm] string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest(new { success = false, message = "ایمیل معتبر نیست." });
            }

            var result = await _service.SendTokenForForgotPassword(new Models.Auth.SendEmailForForgotPasswordCommand
            {
                Email = email
            });

            return new JsonResult(new
            {
                success = result!.IsSuccess,
                message = result.IsSuccess ? null : "مشکلی در ارسال ایمیل پیش آمد."
            });
        
        }
    }
}
