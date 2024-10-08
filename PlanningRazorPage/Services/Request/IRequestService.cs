using PlanningRazorPage.Models;
using PlanningRazorPage.Models.Request;

namespace PlanningRazorPage.Services.Request
{
    public interface IRequestService
    {
        Task<ApiResult> AddRequest(string ReceiverUserName);
        Task<ApiResult> DeleteRequest(string FriendUserName);
        Task<RequestDto?> GetRequestById(long id);
        Task<RequestBoxFilterResult?> GetRequestByFilter(RequestBoxFilterParam param);
        Task<List<RequestDto?>> GetListRequestByUserName();

    }
}
