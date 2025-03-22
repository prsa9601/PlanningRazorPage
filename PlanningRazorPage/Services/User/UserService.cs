using PlanningRazorPage.Models;
using PlanningRazorPage.Models.Event;
using PlanningRazorPage.Models.Friend;
using PlanningRazorPage.Models.User;
using System.Runtime.InteropServices;

namespace PlanningRazorPage.Services.User
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _accessor;
        private const string ModuleName = "User";

        public UserService(IHttpContextAccessor accessor, HttpClient client)
        {
            _accessor = accessor;
            _client = client;
        }

        //public async Task<ApiResult?> AddFriend(AddFriendsUserCommand command)
        //{
        //    var result = await _client.PostAsJsonAsync($"{ModuleName}/AddFriend{command.FriendId}", command);
        //    return await result.Content.ReadFromJsonAsync<ApiResult>();
        //}
        public async Task<ApiResult?> AddFriend(AddFriendsUserCommand command)
        {
            var result = await _client.PostAsJsonAsync($"{ModuleName}/AddFriend", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }
        
        public async Task<ApiResult?> ChangeActivityStatusUserForAdmin(ChangeActivityUserStatusCommand command)
        {
            var result = await _client.PostAsJsonAsync($"{ModuleName}/ChangeActivityStatusForAdmin", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }
        //public async Task<ApiResult?> ChangeActivityUserStatusForAdmin()
        //{
        //    var result = await _client.PatchAsJsonAsync($"{ModuleName}/ChangeActivityStatus", null);
        //    return await result.Content.ReadFromJsonAsync<ApiResult>();
        //}
        
        public async Task<ApiResult?> ChangeEmailConfirmedUserStatusForAdmin(ChangeEmailConfirmedUserStatusCommand command)
        {
            var result = await _client.PostAsJsonAsync($"{ModuleName}/ChangeEmailConfirmedStatusForAdmin", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }
        //public async Task<ApiResult?> ChangeEmailConfirmedStatusForAdmin()
        //{
        //    var result = await _client.PatchAsJsonAsync($"{ModuleName}/ChangeActivityStatus", null);
        //    return await result.Content.ReadFromJsonAsync<ApiResult>();
        //}
        public async Task<ApiResult?> ChangePhoneNumberConfirmedUserStatusForAdmin(ChangePhoneNumberConfirmedStatusCommand command)
        {
            var result = await _client.PostAsJsonAsync($"{ModuleName}/ChangePhoneNumberConfirmedStatusForAdmin", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }
        //public async Task<ApiResult?> ChangePhoneNumberConfirmedStatusForAdmin()
        //{
        //    var result = await _client.PatchAsJsonAsync($"{ModuleName}/ChangeActivityStatus", null);
        //    return await result.Content.ReadFromJsonAsync<ApiResult>();
        //}

        public async Task<ApiResult?> Delete(string Id)
        {
            var result = await _client.DeleteAsync($"{ModuleName}/{Id}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult?> Edit(EditUserCommand command)
        {
            var result = await _client.PutAsJsonAsync($"{ModuleName}", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<UserFilterResult?> SearchUser(UserFilterParam filterParams)
        {
            var url = $"{ModuleName}/searchUser?PageId={filterParams.PageId}&Take={filterParams.Take}";

            if (filterParams.UserName != null)
                url += $"&userName={filterParams.UserName}";

            var result = await _client.GetFromJsonAsync<ApiResult<UserFilterResult?>>(url);
            return result?.Data;
        }
        public async Task<UserDto?> GetByCurrentUser()
        {
            var result = await _client.GetFromJsonAsync<ApiResult<UserDto?>>($"{ModuleName}");
            return result?.Data;
        }
        public async Task<ApiResult> SetRole(SetUserRoleCommand command)
        {
            var result = await _client.PatchAsJsonAsync($"{ModuleName}/setRole", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }
        public async Task<UserDto?> GetByPhoneNumber(string phoneNumber)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<UserDto?>>($"{ModuleName}/GetByPhoneNumber/{phoneNumber}");
            return result?.Data;
        }

        public async Task<UserDto?> GetByUserName(string userName)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<UserDto?>>($"{ModuleName}/GetUserByUserName/{userName}");
            return result?.Data;
        }

        public async Task<ApiResult?> RemoveFriend(string FriendNumber)
        {
            var result = await _client.DeleteAsync($"{ModuleName}/phoneNumber/{FriendNumber}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult?> SetEvent(SetUserEventCommand command)
        {
            var result = await _client.PostAsJsonAsync($"{ModuleName}/SetEvent", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<UserFilterResultForAdmin> SearchUser(UserFilterParamForAdmin filterParams)
        {
            var url = $"{ModuleName}/GetUsersForAdmin?PageId={filterParams.PageId}&Take={filterParams.Take}";

            if (filterParams.UserName != null)
                url += $"&UserName={filterParams.UserName}";
            if (filterParams.UserName != null)
                url += $"&Name={filterParams.Name}";
            if (filterParams.UserName != null)
                url += $"&Family={filterParams.Family}";
            if (filterParams.UserName != null)
                url += $"&PhoneNumber={filterParams.PhoneNumber}";
            if (filterParams.UserName != null)
                url += $"&Email={filterParams.Email}";
            if (filterParams.ActivePackage)
                url += $"&ActivePackage={filterParams.ActivePackage}";

            var result = await _client.GetFromJsonAsync<ApiResult<UserFilterResultForAdmin>>(url);
            return result?.Data;
        }

        public async Task<UserDto?> GetById(string Id)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<UserDto?>>($"{ModuleName}/GetById/{Id}");
            return result?.Data;
        }
    }
}
