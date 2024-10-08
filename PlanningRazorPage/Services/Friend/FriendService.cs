using PlanningRazorPage.Models;
using PlanningRazorPage.Models.Friend;
using PlanningRazorPage.Models.Request;

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

        public async Task<ApiResult> AddFriend(string ReceiverUserName)
        {
            var result = await _client.PostAsJsonAsync(ModuleName, ReceiverUserName);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<List<FriendDto?>> GetListFriendsByUserName()
        {
            var result = await _client.GetFromJsonAsync<ApiResult<List<FriendDto>?>>($"{ModuleName}");
            return result?.Data;
        }

        public async Task<ApiResult> RemoveFriend(string ReceiverUserName)
        {
            var result = await _client.DeleteAsync($"{ModuleName}/{ReceiverUserName}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }
    }
}
