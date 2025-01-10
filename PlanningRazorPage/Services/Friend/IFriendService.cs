using PlanningRazorPage.Models;
using PlanningRazorPage.Models.Friend;
using PlanningRazorPage.Models.User;

namespace PlanningRazorPage.Services.Friend
{
    public interface IFriendService
    {
        Task<ApiResult> AddFriend(string ReceiverUserName);
        Task<ApiResult> RemoveFriend(string ReceiverUserName);
        Task<List<FriendDto>?> GetListFriendsByUserName();
        Task<List<FriendDto>?> GetListFriendsByUserId();
        Task<UserFriendFilterResult?> GetListFriendsByUserIdForProfile(UserFriendFilterParam paramViewModel);
    }
}
