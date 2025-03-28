using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.Friend;
using PlanningRazorPage.Models.User;
using PlanningRazorPage.Services.User;
using System.ComponentModel.DataAnnotations;

namespace PlanningRazorPage.Pages.Admin.User
{
    public class EditModel : BaseRazorPage
    {
        private readonly IUserService _service;

        public EditModel(IUserService service)
        {
            _service = service;
        }

        public UserDto? user { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "نام کاربری الزامی است")]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "ایمیل الزامی است")]
        [EmailAddress(ErrorMessage = "فرمت ایمیل نامعتبر است")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [BindProperty]
        [Display(Name = "نام خانوادگی")]
        public string Family { get; set; }

        [BindProperty]
        [Display(Name = "نام")]
        public string Name { get; set; }

        [BindProperty]
        [Phone(ErrorMessage = "فرمت شماره تماس نامعتبر است")]
        [Display(Name = "شماره تماس")]
        public string PhoneNumber { get; set; }

        [BindProperty]
        [Display(Name = "وضعیت فعال")]
        public bool IsActive { get; set; }
        [BindProperty]
        [Display(Name = "آواتار")]
        public IFormFile? Avatar { get; set; }
        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public UserDto? CurrentUser { get; set; }

        public class InputModel
        {
            public string Id { get; set; } = string.Empty;
        }
        public async Task<IActionResult> OnGet(string id)
        {
            Input = new InputModel { Id = id };
            user = await _service.GetById(id);
            //Input.Avatar =$"{ user!.avatar!.Avatar.ToString()}.png" ?? "Default.pnh";
            return Page();
        }
        public async Task<IActionResult> OnPost(string avatar)
        {
            var result = await _service.EditUserForAdmin(new EditUserCommandForAdmin
            {
                Email = Email,
                Family = Family,
                Name = Name,
                Id = Input.Id,
                PhoneNumber = PhoneNumber,
                userName = UserName,
                IsActive = IsActive,
            });
            if (result.IsSuccess)
                await _service.SetAvatar(new SetAvatarCommand { 
                Avatar = avatar,UserName = UserName});
            return RedirectAndShowAlert(result, Redirect("Index"));
        }
    }
}
