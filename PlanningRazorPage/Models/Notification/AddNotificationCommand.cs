using PlanningRazorPage.Models.Event;

namespace PlanningRazorPage.Models.Notification
{
    public class AddNotificationCommand
    {
        public long EventId { get; set; }
        public bool IsSend { get; set; }
        public bool IsActive { get; set; }
        public bool IsSeen { get; set; }
        public int AllowedEmailCount { get; set; }
        public int AllowedSmsCount { get; set; }
        public DateTime EventStartTime { get; set; }
        public DateTime EventExpiredTime { get; set; }
        public DateTime SendTime { get; set; }
        public string creatorUserName { get; set; }
        public string ScheduleId { get; set; }

        public NotificationType NotificationType { get; set; }
        public ICollection<string> UserIds { get; set; }
    }
    public class AddNotificationViewModel
    {
        public NotificationType NotificationType { get; set; }
        public DateTime SendTime { get; set; }
        public long EventId { get; set; }
        public DateTime EventStartTime { get; set; }
        public List<string> UserIds { get; set; }
    }
    public enum NotificationType
    {
        None,
        Email,
        Sms
    }
    public class EditNotificationCommand 
    {
        public long EventId { get; set; }
        public long NotificationId { get; set; }
        public bool IsSend { get; set; }
        public bool IsActive { get; set; }
        public bool IsSeen { get; set; }
        public int AllowedEmailCount { get; set; }
        public int AllowedSmsCount { get; set; }
        public DateTime EventStartTime { get; set; }
        public DateTime EventExpiredTime { get; set; }
        public DateTime SendTime { get; set; }
        public string ScheduleId { get; set; }

        public NotificationType NotificationType { get; set; }
        public ICollection<string> UserIds { get; set; }
    }
    public class RemoveNotificationCommand 
    {
        //public string ScheduleId { get; set; }
        public long EventId { get; set; }
    }

    public class SendNotificationByEmailCommand
    {
        public long notificationId { get; set; }
        public long EventId { get; set; }
        public List<string>? userNames { get; set; }
        public DateTime startTime { get; set; }
    }
    public class EditNotificationViewModel
    {
        //public long NotificationId { get; set; }
        public NotificationType NotificationType { get; set; }
        public DateTime SendTime { get; set; }
        public DateTime EventEndTime { get; set; }
        public long EventId { get; set; }
        public DateTime EventStartTime { get; set; }
        public List<string> UserNames { get; set; }
    }
    public class ChangeDateNotificationCommand 
    {
        public long EventId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime SendTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
