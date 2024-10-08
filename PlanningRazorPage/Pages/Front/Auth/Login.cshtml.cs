using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using PlanningRazorPage.Models.Auth;
using PlanningRazorPage.Services.Auth;
using System.ComponentModel.DataAnnotations;

namespace PlanningRazorPage.Pages.Front.Auth
{
    public class LoginModel : PageModel
    {
        private readonly IAuthService _authService;

        public LoginModel(IAuthService service)
        {
            _authService = service;
        }

        [Display(Name = "????? ????")]
        [Required(ErrorMessage = "{0} ?? ???? ????")]
        public string UserName { get; set; }

        [Display(Name = "???? ????")]
        [Required(ErrorMessage = "{0} ?? ???? ????")]
        [MinLength(5, ErrorMessage = "???? ???? ???? ?????? ?? 5 ??????? ????")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string? RedirectTo { get; set; }
        public IActionResult OnGet(string redirectTo)
        {
            //if (User.Identity.IsAuthenticated)
            //    return Redirect("/");

            RedirectTo = redirectTo;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var result = await _authService.Login(new LoginCommand()
            {
                Password = Password,
                UserName = UserName
            });
            if (result.IsSuccess == false)
            {
                ModelState.AddModelError(nameof(UserName), result.MetaData.Message);
                return Page();
            }

            //var token = result.Data.Token;
            //var refreshToken = result.Data.RefreshToken;
            //HttpContext.Response.Cookies.Append("token", token, new CookieOptions()
            //{
            //    HttpOnly = true,
            //    Expires = DateTimeOffset.Now.AddDays(7)
            //});
            //HttpContext.Response.Cookies.Append("refresh-token", refreshToken, new CookieOptions()
            //{
            //    HttpOnly = true,
            //    Expires = DateTimeOffset.Now.AddDays(10)
            //});

            //await SyncShopCart(token);
            if (string.IsNullOrWhiteSpace(RedirectTo) == false)
            {
                return LocalRedirect(RedirectTo);
            }
            return Redirect("../Index");
            //return RedirectToPage("detail", new { slug = post.Slug });
        }
    }
}
