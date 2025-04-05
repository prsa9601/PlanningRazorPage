using PlanningRazorPage.Models;
using PlanningRazorPage.Models.Friend;
using PlanningRazorPage.Models.Request;
using PlanningRazorPage.Models.User;

namespace PlanningRazorPage.Services.Friend
{
    public class FriendService : IFriendService
    {
        private readonly HttpClient _client;
        private const string ModuleName = "FriendUser";

        public FriendService(HttpClient client)
        {
            _client = client;
        }
        public async Task<UserFriendFilterResult?> GetListFriendsByUserIdForProfile(UserFriendFilterParam filterParams)
        {
            var url = $"{ModuleName}/GetFriendsForProfile?PageId={filterParams.PageId}&Take={filterParams.Take}";

            if (filterParams.UserName != null)
                url += $"&userName={filterParams.UserName}";

            var result = await _client.GetFromJsonAsync<ApiResult<UserFriendFilterResult?>>(url);
            return result?.Data;
        }

        public async Task<SearchFriendForEventFilterResult?> SearchFriendForEvent(SearchFriendForEventFilterParamModel param)
        {
            var url = $"{ModuleName}/SearchFriendForEvent?PageId={param.PageId}&Take={param.Take}";

            if (!string.IsNullOrEmpty(param.UserName))
                url += $"&userName={param.UserName}";

            var result = await _client.GetFromJsonAsync<ApiResult<SearchFriendForEventFilterResult?>>(url);
            return result?.Data;
        }

        public async Task<ApiResult> AddFriend(string ReceiverUserName)
        {
            var result = await _client.PostAsJsonAsync(ModuleName, ReceiverUserName);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<List<FriendDto>?> GetListFriendsByUserName()
        {
            var result = await _client.GetFromJsonAsync<ApiResult<List<FriendDto>?>>($"{ModuleName}");
            return result?.Data;
        }

        //public async Task<UserFriendFilterResult?> SearchUser(UserFriendFilterParam filterParams)
        //{
        //    var url = $"{ModuleName}/GetByUserIdForProfile?PageId={filterParams.PageId}&Take={filterParams.Take}";

        //    if (filterParams.UserName != null)
        //        url += $"&userName={filterParams.UserName}";

        //    var result = await _client.GetFromJsonAsync<ApiResult<UserFriendFilterResult?>>(url);
        //    return result?.Data;
        //}

        public async Task<List<FriendDto>?> GetListFriendsByUserId()
        {
            var result = await _client.GetFromJsonAsync<ApiResult<List<FriendDto>?>>($"{ModuleName}/GetByUserId");
            return result?.Data;
        }

     

        public async Task<ApiResult> RemoveFriend(string ReceiverUserName)
        {
            var result = await _client.DeleteAsync($"{ModuleName}?ReceiverUserName={ReceiverUserName}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }
    }
}
