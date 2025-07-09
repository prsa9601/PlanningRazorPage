using PlanningRazorPage.Models;
using PlanningRazorPage.Models.Notification;
using PlanningRazorPage.Models.Role;

namespace PlanningRazorPage.Services.Notification
{
    public interface INotificationService
    {
        Task<ApiResult?> SendEmail(SendNotificationByEmailCommand command);
        Task<ApiResult<long>> Add(AddNotificationViewModel command);
        Task<ApiResult?> Edit(EditNotificationViewModel command);
        Task<ApiResult?> MarkAsRead(MarkAsReadNotificationViewModel command);
        Task<ApiResult?> ChangeDate(ChangeDateNotificationCommand command);
        Task<ApiResult?> Remove(RemoveNotificationCommand command);
        Task<NotificationDto?> GetByIdNotificationsCurrentUser(long NotificationId);
        Task<NotificationFilterResult> GetFilterNotificationsCurrentUser(NotificationFilterParamViewModel param);
    }
    public class NotificationService : INotificationService
    {
        private readonly HttpClient _client;
        private const string ModuleName = "Notification";

        public NotificationService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ApiResult?> SendEmail(SendNotificationByEmailCommand command)
        {
            var result = await _client.PostAsJsonAsync($"{ModuleName}/SendEmail", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult<long>> Add(AddNotificationViewModel command)
        {
            var result = await _client.PostAsJsonAsync($"{ModuleName}/AddNotification", command);
            return await result.Content.ReadFromJsonAsync<ApiResult<long>>();
        }

        public async Task<ApiResult?> Edit(EditNotificationViewModel command)
        {
            var result = await _client.PatchAsJsonAsync($"{ModuleName}/EditNotification", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult?> Remove(RemoveNotificationCommand command)
        {
            var result = await _client.DeleteAsync($"{ModuleName}/" +
                $"RemoveNotification/{command.EventId}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult?> ChangeDate(ChangeDateNotificationCommand command)
        {
            var result = await _client.PatchAsJsonAsync($"{ModuleName}/ChangeDateNotification", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<NotificationDto?> GetByIdNotificationsCurrentUser(long NotificationId)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<NotificationDto?>>($"{ModuleName}/GetByIdNotificationsCurrentUser&NotificationId={NotificationId}");
            return result?.Data;
        }

        public async Task<NotificationFilterResult> GetFilterNotificationsCurrentUser(NotificationFilterParamViewModel param)
        {
            //var url = $"{ModuleName}/filter?PageId={param.PageId}&Take={param.Take}";
            var url = $"{ModuleName}/GetFilterNotificationsCurrentUser?PageId={param.PageId}&Take={param.Take}";

            var result = await _client.GetFromJsonAsync<ApiResult<NotificationFilterResult>>(url);
            return result.Data;
        }

        public async Task<ApiResult?> MarkAsRead(MarkAsReadNotificationViewModel command)
        {
            var result = await _client.PatchAsJsonAsync($"{ModuleName}/MarkNotificationAsRead", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }
    }
}
