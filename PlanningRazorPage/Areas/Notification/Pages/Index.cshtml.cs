using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.User.UserNotification;
using PlanningRazorPage.Services.User.UserNotification;

namespace PlanningRazorPage.Areas.Notification.Pages
{
    [Area("Notification")]
    public class IndexModel : BaseRazorFilter<UserNotificationFilterParamForAdmin>
    {
        private readonly IUserNotificationService _service;

        public IndexModel(IUserNotificationService service)
        {
            _service = service;
        }
        [BindProperty(SupportsGet = true)]
        public UserNotificationFilterResultForAdmin UserNotifications { get; set; }
        //[Route()]
        public async Task<IActionResult> OnGet(long PageId)
        {
            UserNotifications = await _service.GetUserNotificationFilterForAdmin(FilterParams);
            return Page();
        }
        public async Task<IActionResult> OnPostDelete(long id)
        {
            var result = await _service.RemoveUserNotification(
                new RemoveUserNotificationViewModel(id));
            return new JsonResult(new
            {
                success = result.IsSuccess,
                isreload = result.IsReload, 
                notificationId = id
            });
        }
    }
}


