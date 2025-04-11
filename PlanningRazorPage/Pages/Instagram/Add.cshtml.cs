using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace PlanningRazorPage.Pages.Instagram
{
    public class AddModel : PageModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "نام کاربری الزامی است")]
        [Display(Name = "نام کاربری اینستاگرام")]
        public string Username { get; set; }

        [Required(ErrorMessage = "ایمیل الزامی است")]
        [EmailAddress(ErrorMessage = "فرمت ایمیل نامعتبر است")]
        public string Email { get; set; }

        [Required(ErrorMessage = "رمز عبور الزامی است")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "توضیحات پروفایل")]
        [StringLength(150, ErrorMessage = "حداکثر ۱۵۰ کاراکتر مجاز است")]
        public string Bio { get; set; }

        [Display(Name = "شماره تلفن")]
        [Phone(ErrorMessage = "شماره تلفن نامعتبر است")]
        public string PhoneNumber { get; set; }
        public void OnGet()
        {
        }
    }
}
