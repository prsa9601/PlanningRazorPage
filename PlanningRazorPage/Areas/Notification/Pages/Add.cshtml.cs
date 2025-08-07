using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Infrastructure.Utils;
using PlanningRazorPage.Models.User.UserNotification;
using PlanningRazorPage.Services.Friend;
using PlanningRazorPage.Services.User;
using PlanningRazorPage.Services.User.UserNotification;

namespace PlanningRazorPage.Areas.Notification
{
    [Area("Notification")]
    public class AddModel : BaseRazorPage
    {
        private readonly IUserNotificationService _service;

        public AddModel(IUserNotificationService service)
        {
            _service = service;
        }
        public class requestData
        {
            public required string Title { get; set; }
            public required string Description { get; set; }
            public bool IsActive { get; set; } //ارسال بشه یانه
            public string SendTimeDate { get; set; }
            public bool SendToAllUser { get; set; }
            public required string NotificationType { get; set; }

            public List<string>? UserIds { get; set; }
        }
        [BindProperty(SupportsGet = true)]
        public Dictionary<string, string> informations { get; set; }
        public async Task<IActionResult> OnGet()
        {
            informations = await _service.GetUserNamesForAdmin();
            return Page();
        }
        public async Task<IActionResult> OnGetInformation()
        {
            informations = await _service.GetUserNamesForAdmin();
            return new JsonResult(new { informations = informations });
        }
        public async void OnPostAddNotification([FromBody] requestData requestData)
        {
            List<string> userNotificationType = new();
            var requestUserNotificationType = requestData.NotificationType.Split(",");
            int i = 0;
            foreach (var item in requestUserNotificationType)
            {
                userNotificationType.Add(requestUserNotificationType[i]);
                i++;
            }
            UserNotificationType NotificationSendType = new UserNotificationType();
            if (requestUserNotificationType.Any(i => i.Equals(UserNotificationType.Website.ToString())))
            {
                NotificationSendType |= UserNotificationType.Website;
            }
            if (requestUserNotificationType.Any(i => i.Equals(UserNotificationType.Email.ToString())))
            {
                NotificationSendType |= UserNotificationType.Email;
            }
            if (requestUserNotificationType.Any(i => i.Equals(UserNotificationType.Sms.ToString())))
            {
                NotificationSendType |= UserNotificationType.Sms;
            }

            DateTime date = DateTime.Now;
            if (requestData.SendTimeDate != null)
            {
                date = requestData.SendTimeDate!.ConvertToGregorianDateTime();

            }
            var result = await _service.AddUserNotification(new Models.User.UserNotification.
                AddUserNotificationCommandViewModel
            {
                Description = requestData.Description,
                IsActive = requestData.IsActive,
                Title = requestData.Title,
                NotificationType = NotificationSendType,
                UserIds = requestData.UserIds,
                SendTime = date == null ? DateTime.MinValue : date,
                SendToAllUser = requestData.SendToAllUser,
            });
        }
    }
}
