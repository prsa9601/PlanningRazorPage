using PlanningRazorPage.Models.Notification;
using PlanningRazorPage.Models.User.UserNotification;
using System.Security.Claims;

namespace PlanningRazorPage.Models.GlobalNotification
{

    #region globoalNotification
    public class MarkAsReadUserNotificationViewModel
    {
        public long UserNotificationId { get; set; }
    }
    public class GlobalNotificationFilterData : BaseDto
    {
        //public long? EventId { get;  set; }
        public bool IsSend { get; set; }
        public bool IsActive { get; set; } //برای وقتی که تایم پکیج تموم شد
        //public DateTime EventStartTime { get; set; }
        //public DateTime EventEndTime { get; set; }
        public DateTime SendTime { get; set; }
        public bool IsSeen { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }

        public GlobalGetType globalGetType { get; set; }
        public GlobalNotificationType NotificationType { get; set; }
        //public ICollection<string>? UserNames { get; set; }
        public string UserName { get; set; }

        //public EventNotificationDto? eventDto { get; set; }
    }
    [Flags]
    public enum GlobalNotificationType
    {
        None,
        Website,
        Email,
        Sms
    }
    public enum GlobalGetType
    {
        Notification,
        UserNotification
    }
    public class GlobalNotificationFilterParam : BaseFilterParam
    {
        public required string UserId { get; set; }
    }
    public class GlobalNotificationFilterResult : BaseFilter<GlobalNotificationFilterData, GlobalNotificationFilterParam>
    {
    }

    #endregion
    #region MapGlobalNotification
    public static class GlobalNotificationMapper
    {
        public static GlobalNotificationFilterResult Map(
            this NotificationFilterResult notification, UserNotificationFilterResult userNotification)
        {
            List<GlobalNotificationFilterData> result = new();
            foreach (var item in notification.Data)
            {
                result.Add(
                     new GlobalNotificationFilterData
                     {
                         Description = item.Description,
                         CreationDate = item.CreationDate,
                         Id = item.Id,
                         IsActive = item.IsActive,
                         globalGetType = GlobalGetType.Notification,
                         SendTime = item.SendTime,
                         IsSeen = item.IsSeen,
                         IsSend = item.IsSend,
                         NotificationType = item.NotificationType switch
                         {
                             NotificationType.Email => GlobalNotificationType.Email,
                             NotificationType.Sms => GlobalNotificationType.Sms,
                             _ => GlobalNotificationType.None,
                         },
                         Title = item.Title,
                         UserName = item.UserNames.FirstOrDefault(i => i.Equals(
                             Convert.ToString(ClaimsPrincipal.Current.FindFirst(ClaimTypes.Name)?.Value)))!,

                     });
            }
            foreach (var userNotif in userNotification.Data)
            {
                result.Add(new GlobalNotificationFilterData
                {
                    Description = userNotif.Description,
                    CreationDate = userNotif.CreationDate,
                    Id = userNotif.Id,
                    globalGetType = GlobalGetType.UserNotification,
                    IsActive = userNotif.IsActive,
                    SendTime = userNotif.SendTime,
                    IsSeen = userNotif.IsSeen,
                    IsSend = userNotif.IsSend,
                    NotificationType = userNotif.SendType switch
                    {
                        UserNotificationType.Email => GlobalNotificationType.Email,
                        UserNotificationType.Website => GlobalNotificationType.Website,
                        UserNotificationType.Sms => GlobalNotificationType.Sms,
                        _ => GlobalNotificationType.None,
                    },
                    Title = userNotif.Title,
                    UserName = userNotif.UserName,
                });
            }
            return new GlobalNotificationFilterResult
            {
                Data = result.OrderByDescending(i => i.SendTime).ToList(),
                EntityCount = result.Count,
            };
        }
        public static GlobalNotificationFilterResult Map(this UserNotificationFilterResult model)
        {
            throw new Exception();
        }
    }
    #endregion
}
