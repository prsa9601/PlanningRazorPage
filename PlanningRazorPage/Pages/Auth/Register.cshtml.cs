using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.Auth;
using PlanningRazorPage.Services.Auth;
using System.ComponentModel.DataAnnotations;

namespace PlanningRazorPage.Pages.Auth
{
    [BindProperties]
    public class RegisterModel : BaseRazorPage
    {
        private readonly IAuthService _service;

        [Display(Name = " ??? ??????")]
        [Required(ErrorMessage = "{0} ?? ???? ????")]
        public string UserName { get; set; }

        [Display(Name = "????? ????")]
        [Required(ErrorMessage = "{0} ?? ???? ????")]
        public string PhoneNumber { get; set; }

        [Display(Name = "???? ????")]
        [Required(ErrorMessage = "{0} ?? ???? ????")]
        [MinLength(5, ErrorMessage = "???? ???? ???? ?????? ?? 5 ??????? ????")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "?????")]
        [Required(ErrorMessage = "{0} ?? ???? ????")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public RegisterModel(IAuthService service)
        {
            _service = service;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            var result = await _service.Register(new RegisterCommand()
            {
                Email = Email,
                Password = Password,
                PhoneNumber = PhoneNumber,
                UserName = UserName
            });
            if (result.IsSuccess)
            {
                var loginResult = await _service.Login(new LoginCommand
                {
                    Password=Password,
                    rememberMe = false,
                    UserName = UserName
                });
                if (loginResult.IsSuccess)
                {
                    var token = loginResult.Data.Token;
                    //var refreshToken = result.Data.RefreshToken;
                    HttpContext.Response.Cookies.Append("token", token, new CookieOptions()
                    {
                        HttpOnly = true,
                        Expires = DateTimeOffset.Now.AddDays(7)
                    });
                    return RedirectAndShowAlert(result, Redirect("~/Index"));
                }

            }
            return RedirectAndShowAlert(result, Redirect("~/Index"));
        }
    }
}
