using PlanningRazorPage.Models.Friend;

namespace PlanningRazorPage.Models.User
{
    public class UserDto : BaseDto
    {
        public string Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public UserAvatarDto? avatar { get; set; }
        public string Email { get; set; }

        public List<FriendsDto> friends { get; set; }
    }
    public class UserDtoForFriendProfile : BaseDto
    {
        public string Id { get; set; }
        public string CurrentUserId { get; set; }
        public DateTime CreationDate { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public UserAvatarDto? avatar { get; set; }
        public string Email { get; set; }

        public List<FriendsDto> friends { get; set; }
    }
    public class UserAvatarDto : BaseDto
    {
        public string? UserId { get; set; }
        public Avatar Avatar { get; set; } = Avatar.Default;
    }
    public class FriendsDto : BaseDto
    {
        public string CurrentUserId { get; set; }
        public string UserFriend { get; set; }
    }
    public class UserFilterData : BaseDto
    {
    }
    public class UserFilterParam : BaseFilterParam
    {
        public string UserName { get; set; } = string.Empty;
    }
    public class UserFilterResult : BaseFilter<UserDtoForFriendProfile, UserFilterParam>
    {
    }
}
