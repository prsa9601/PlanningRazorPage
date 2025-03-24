using PlanningRazorPage.Models.Auth;
using PlanningRazorPage.Models;
using PlanningRazorPage.Models.User;
using PlanningRazorPage.Models.Friend;

namespace PlanningRazorPage.Services.User
{
    public interface IUserService
    {
        Task<ApiResult?> AddFriend(AddFriendsUserCommand command);
        Task<ApiResult?> Delete(string Id);
        Task<ApiResult?> RemoveFriend(string FriendNumber);
        Task<ApiResult?> Edit(EditUserCommand command);
        Task<ApiResult?> EditUserForAdmin(EditUserCommandForAdmin command);
        Task<ApiResult?> SetEvent(SetUserEventCommand command);
        Task<ApiResult> SetRole(SetUserRoleCommand command); 
        Task<ApiResult> ChangeActivityStatusUserForAdmin(ChangeActivityUserStatusCommand command);
        Task<ApiResult> ChangeEmailConfirmedUserStatusForAdmin(ChangeEmailConfirmedUserStatusCommand command);
        Task<ApiResult> ChangePhoneNumberConfirmedUserStatusForAdmin(ChangePhoneNumberConfirmedStatusCommand command);


        Task<UserDto?> GetById(string Id);
        Task<UserDto?> GetByPhoneNumber(string phoneNumber);
        Task<UserFilterResult?> SearchUser(UserFilterParam param);
        Task<UserFilterResultForAdmin?> SearchUser(UserFilterParamForAdmin filterParams);
        Task<UserDto?> GetByCurrentUser();
        Task<UserDto?> GetByUserName(string userName);

    }
}
