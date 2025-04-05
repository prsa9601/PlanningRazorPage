using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.Notification;
using PlanningRazorPage.Services.Notification;

namespace PlanningRazorPage.Pages.Front.Profile
{
    public class NotificationModel : BaseRazorFilter<NotificationFilterParamViewModel>
    {
        private readonly INotificationService _service;

        public NotificationModel(INotificationService service)
        {
            _service = service;
        }
        public NotificationFilterResult? Notifications { get; set; }
        public async Task<IActionResult> OnGet(string UserName = "", int Take = 8, int PageId = 1)
        {
            Notifications = await _service.GetFilterNotificationsCurrentUser(new Models.Notification.NotificationFilterParamViewModel
            {
                //UserName = UserName,
                Take = Take,
                PageId = PageId

            });
            return Page();
        }
    }
}
