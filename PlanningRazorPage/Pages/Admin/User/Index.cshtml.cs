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

        public IndexModel(IUserService service)
        {
            _service = service;
        }
        public UserFilterResultForAdmin? Users { get; set; }
        public async Task OnGet(int pageId = 1, int take = 8, 
            string userName = null!, bool activePackage = true,
            string name = "", string family = "",
            string email = "", string phoneNumber="")
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
    }
}
//public async Task<IActionResult> OnPostToggleIsActive(string userId)
//{
//    var user = await _userManager.FindByIdAsync(userId);
//    if (user != null)
//    {
//        user.IsActive = !user.IsActive;
//        await _userManager.UpdateAsync(user);
//    }
//    return new JsonResult(new { success = true });
//}

//public async Task<IActionResult> OnPostTogglePhoneNumberConfirmed(string userId)
//{
//    var user = await _userManager.FindByIdAsync(userId);
//    if (user != null)
//    {
//        user.PhoneNumberConfirmed = !user.PhoneNumberConfirmed;
//        await _userManager.UpdateAsync(user);
//    }
//    return new JsonResult(new { success = true });
//}

//public async Task<IActionResult> OnPostToggleEmailConfirmed(string userId)
//{
//    var user = await _userManager.FindByIdAsync(userId);
//    if (user != null)
//    {
//        user.EmailConfirmed = !user.EmailConfirmed;
//        await _userManager.UpdateAsync(user);
//    }
//    return new JsonResult(new { success = true });
//}