using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.User;
using PlanningRazorPage.Services.User;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;

namespace PlanningRazorPage.Pages.Admin.User
{
    public class IndexModel : BaseRazorFilter<UserFilterParamForAdmin>
    {
        private readonly IUserService _service;
        //private readonly ILogger _logger;

        public IndexModel(IUserService service)
        {
            _service = service;
            //_logger = logger;
        }
        public UserFilterResultForAdmin? Users { get; set; }
        public async Task OnGet(int pageId = 1, int take = 8,
            string userName = null!, bool activePackage = true,
            string name = "", string family = "",
            string email = "", string phoneNumber = "")
        {
            Users = await _service.SearchUser(new UserFilterParamForAdmin()
            {
                PageId = pageId,
                ActivePackage = activePackage,
                Email = email,
                Family = family,
                Name = name,
                PhoneNumber = phoneNumber,
                Take = take,
                UserName = userName
            });
        }
        public void OnPost()
        {
        }
        public async Task<IActionResult> OnPostToggleIsActive(string userId, bool IsActive)
        {
            bool isActive = !IsActive;
            var result = await _service.ChangeActivityStatusUserForAdmin(new ChangeActivityUserStatusCommand
            {
                UserId = userId,
                IsActive = isActive
            });
            return new JsonResult(new { success = true });
        }

        public async Task<IActionResult> OnPostTogglePhoneNumberConfirmed(string userId,
            bool IsActive)
        {
            var result = await _service.ChangePhoneNumberConfirmedUserStatusForAdmin(new ChangePhoneNumberConfirmedStatusCommand
            {
                UserId = userId,
                PhoneNumberConfirmed = !IsActive
            });
            return new JsonResult(new { success = true });
        }

        public async Task<IActionResult> OnPostToggleEmailConfirmed(string userId, bool IsActive)
        {
            var result = await _service.ChangeEmailConfirmedUserStatusForAdmin(new ChangeEmailConfirmedUserStatusCommand
            {
                UserId = userId,
                EmailConfirmed = !IsActive
            });
            return new JsonResult(new { success = true });
        }

        public async Task<IActionResult> OnPostDelete(string id)
        {
            try
            {
                var result = await _service.Delete(id);

                if (!result.IsSuccess)
                {
                    return new JsonResult(new
                    {
                        success = false,
                        //message = string.Join(", ", result.Errors.Select(e => e.Description))
                        message = string.Join(", ", result.MetaData.Message),
                    });
                }

                return new JsonResult(new { success = true, message = "حذف با موفقیت انجام شد" });
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "خطا در حذف کاربر");
                return new JsonResult(new
                {
                    success = false,
                    message = "خطای داخلی سرور. لطفا مجددا تلاش کنید"
                });
            }
        }
    }


}