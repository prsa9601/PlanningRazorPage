
using PlanningRazorPage.Models.Auth;
using PlanningRazorPage.Models;
using PlanningRazorPage.Models.User;

namespace PlanningRazorPage.Services.User
{
    public interface IUserService
    {
        Task<ApiResult?> AddFriend(AddFriendsUserCommand command);
        Task<ApiResult?> Delete(string Id);
        Task<ApiResult?> RemoveFriend(string FriendNumber);
        Task<ApiResult?> Edit(EditUserCommand command);
        Task<ApiResult?> SetEvent(SetUserEventCommand command);
        Task<UserDto?> GetByPhoneNumber(string phoneNumber);
        Task<UserDto?> GetByCurrentUser();
        Task<UserDto?> GetByUserName(string userName);

    }
}
