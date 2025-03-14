using PlanningRazorPage.Models;
using PlanningRazorPage.Models.Notification;

namespace PlanningRazorPage.Services.Notification
{
    public interface INotificationService
    {
        Task<ApiResult?> SendEmail(SendNotificationByEmailCommand command);
        Task<ApiResult<long>?> Add(AddNotificationViewModel command);
        Task<ApiResult?> Edit(EditNotificationViewModel command);
        Task<ApiResult?> Remove(RemoveNotificationCommand command);
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

        public async Task<ApiResult<long>?> Add(AddNotificationViewModel command)
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
                $"RemoveNotification?EventId={command.EventId}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }
    }
}
