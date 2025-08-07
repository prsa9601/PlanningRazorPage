using PlanningRazorPage.Models;
using PlanningRazorPage.Models.GlobalNotification;
using PlanningRazorPage.Models.User;
using PlanningRazorPage.Models.User.UserNotification;

namespace PlanningRazorPage.Services.User.UserNotification
{
    public class UserNotificationService : IUserNotificationService
    {
        private readonly HttpClient _client;
        private const string ModuleName = "UserNotification";
        public UserNotificationService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ApiResult> AddUserNotification(AddUserNotificationCommandViewModel command)
        {
            var result = await _client.PostAsJsonAsync($"{ModuleName}/Add", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<UserNotificationDto?> GetUserNotificationById(long UserNotificationId)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<UserNotificationDto>>($"{ModuleName}/GetById?{UserNotificationId}");
            return result?.Data;
        }

        public async Task<UserNotificationFilterResult> GetUserNotificationFilter(UserNotificationFilterParamViewModel param)
        {
            var url = $"{ModuleName}/GetFilter?PageId={param.PageId}&Take={param.Take}";

            if (param.Search!= null)
                url += $"&Search={param.Search}";

            var result = await _client.GetFromJsonAsync<ApiResult<UserNotificationFilterResult>>(url);
            return result?.Data;
        }
        
        public async Task<UserNotificationFilterResult> GetUserNotificationFilterForLayout(UserNotificationFilterParamViewModel param)
        {
            var url = $"{ModuleName}/GetFilterForLayout?PageId={param.PageId}&Take={param.Take}";

            if (param.Search!= null)
                url += $"&Search={param.Search}";

            var result = await _client.GetFromJsonAsync<ApiResult<UserNotificationFilterResult>>(url);
            return result?.Data;
        }

        public async Task<UserNotificationFilterResultForAdmin> GetUserNotificationFilterForAdmin(UserNotificationFilterParamForAdmin param)
        {
            var url = $"{ModuleName}/GetFilterForAdmin?PageId={param.PageId}&Take={param.Take}";

            if (param.Search != null)
                url += $"&Search={param.Search}";
            
            if (param.IsSend!= null)
                url += $"&IsSend={param.IsSend}";

            var result = await _client.GetFromJsonAsync<ApiResult<UserNotificationFilterResultForAdmin>>(url);
            return result?.Data;
        }
        public async Task<Dictionary<string, string>> GetUserNamesForAdmin()
        {
            var result = await _client.GetFromJsonAsync
                <ApiResult<Dictionary<string, string>>>($"{ModuleName}/GetInformationUserForAdmin");
            return result?.Data;
        }

        public async Task<ApiResult> RemoveAllUserNotifications()
        {
            var result = await _client.DeleteAsync
                ($"{ModuleName}/RemoveAll");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> RemoveAllUserNotificationsForUser()
        {
            var result = await _client.DeleteAsync
                ($"{ModuleName}/RemoveAllForUser");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> RemoveUserNotification(RemoveUserNotificationViewModel model)
        {
            var result = await _client.DeleteAsync
                ($"{ModuleName}/Remove?UserNotificationId={model.UserNotificationId}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> RemoveUserNotificationForUser(RemoveUserNotificationViewModel model)
        {
            var result = await _client.DeleteAsync
                ($"{ModuleName}/RemoveForUser{model.UserNotificationId}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> MarkAsRead(MarkAsReadUserNotificationViewModel command)
        {
            var result = await _client.PatchAsJsonAsync($"{ModuleName}/MarkUserNotificationAsRead", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }
    }
}
