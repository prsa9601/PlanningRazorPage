using System.ComponentModel;

namespace PlanningRazorPage.Models.User.UserNotification
{
    public record class RemoveUserNotificationViewModel(long UserNotificationId);
    public class UserNotificationFilterParamForAdminViewModel
    {
        public int PageId { get; set; } = 1;
        public int Take { get; set; } = 10;
        public string? Search { get; set; }
    }
    public class UserNotificationFilterParamViewModel : BaseFilterParam
    {
        public string? Search { get; set; }
    }
    public class AddUserNotificationCommandViewModel
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public bool IsActive { get; set; } //ارسال بشه یانه
        public DateTime SendTime { get; set; }
        public bool SendToAllUser { get; set; }
        public required UserNotificationType NotificationType { get; set; }

        public List<string>? UserIds { get; set; }
    }

    [Flags]
    public enum UserNotificationType
    {
        //[Description("هیچکدام")]
        //None = 0,

        //[Description("وبسایت")]
        //Website = 1,

        //[Description("ایمیل")]
        //Email = 2,

        //[Description("پیامک")]
        //Sms = 3

        [Description("هیچکدام")]
        None = 0,          // 0000

        [Description("وبسایت")]
        Website = 1,       // 0001

        [Description("ایمیل")]
        Email = 1 << 1,    // 0010 (یا 2)

        [Description("پیامک")]
        Sms = 1 << 2       // 0100 (یا 4)
    }
}
