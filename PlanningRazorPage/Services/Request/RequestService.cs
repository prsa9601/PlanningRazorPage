using PlanningRazorPage.Models;
using PlanningRazorPage.Models.Request;

namespace PlanningRazorPage.Services.Request
{
    public class RequestService : IRequestService
    {
        private readonly HttpClient _client;
        private const string ModuleName = "RequestUser";

        public RequestService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ApiResult> AddRequest(string ReceiverUserName)
        {
            var result = await _client.PostAsJsonAsync(ModuleName, ReceiverUserName);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> DeleteRequest(string FriendUserName)
        {
            var result = await _client.DeleteAsync($"{ModuleName}?FriendUserName={FriendUserName}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<List<RequestDto?>> GetListRequestByUserName()
        {
            var result = await _client.GetFromJsonAsync<ApiResult<List<RequestDto?>>>($"{ModuleName}/getById/");
            return result?.Data;
        }

        public async Task<RequestBoxFilterResult?> GetRequestByFilter(RequestBoxFilterParam param)
        {
            var url = $"{ModuleName}/GetFilter?PageId={param.PageId}&Take={param.Take}";

            if (param.filter != null)
                url += $"&filter={param.filter}";

            var result = await _client.GetFromJsonAsync<ApiResult<RequestBoxFilterResult>>(url);
            return result?.Data;
        }

        public async Task<RequestDto?> GetRequestById(long id)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<RequestDto?>>($"{ModuleName}/getById/{id}");
            return result?.Data;
        }
    }
}
