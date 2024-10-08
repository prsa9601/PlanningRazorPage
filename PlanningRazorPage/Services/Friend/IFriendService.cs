using PlanningRazorPage.Models;
using PlanningRazorPage.Models.Friend;

namespace PlanningRazorPage.Services.Friend
{
    public interface IFriendService
    {
        Task<ApiResult> AddFriend(string ReceiverUserName);
        Task<ApiResult> RemoveFriend(string ReceiverUserName);
        Task<List<FriendDto?>> GetListFriendsByUserName();
    }
}
