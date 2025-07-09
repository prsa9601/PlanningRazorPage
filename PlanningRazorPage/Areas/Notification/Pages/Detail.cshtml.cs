using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Models.User.UserNotification;

namespace PlanningRazorPage.Areas.Notification.Pages
{
    public class DetailModel : PageModel
    {
        public UserNotificationDtoForAdmin Notification { get; set; }
        public void OnGet(long id)
        {
        }
    }
}
