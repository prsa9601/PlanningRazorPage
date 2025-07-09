using Microsoft.AspNetCore.Mvc;
using PlanningRazorPage.Models;
using PlanningRazorPage.Models.GlobalNotification;
using PlanningRazorPage.Models.User.UserNotification;

namespace PlanningRazorPage.Services.User.UserNotification
{
    public interface IUserNotificationService
    {
        Task<ApiResult> AddUserNotification(AddUserNotificationCommandViewModel command);
        Task<ApiResult> RemoveUserNotification(RemoveUserNotificationViewModel model);
        Task<ApiResult> RemoveAllUserNotifications();
        Task<ApiResult> MarkAsRead(MarkAsReadUserNotificationViewModel command);
        Task<ApiResult> RemoveAllUserNotificationsForUser();
        Task<ApiResult> RemoveUserNotificationForUser(RemoveUserNotificationViewModel model);

        Task<UserNotificationDto?> GetUserNotificationById(long UserNotificationId);
        Task<Dictionary<string, string>> GetUserNamesForAdmin();

        Task<UserNotificationFilterResult> GetUserNotificationFilter
            (UserNotificationFilterParamViewModel param);
        Task<UserNotificationFilterResult> GetUserNotificationFilterForLayout(
            UserNotificationFilterParamViewModel param);

        Task<UserNotificationFilterResultForAdmin> GetUserNotificationFilterForAdmin
            (UserNotificationFilterParamForAdmin param);

    }
}
