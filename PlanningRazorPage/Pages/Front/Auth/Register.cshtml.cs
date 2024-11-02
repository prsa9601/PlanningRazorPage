using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.Auth;
using PlanningRazorPage.Services.Auth;
using System.ComponentModel.DataAnnotations;

namespace PlanningRazorPage.Pages.Front.Auth
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
            return RedirectAndShowAlert(result, Redirect("~/Index"));
        }
    }
}
