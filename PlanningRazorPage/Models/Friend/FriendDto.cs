namespace PlanningRazorPage.Models.Friend
{
    public class FriendDto : BaseDto
    {
        public string? UserId { get; set; }
        public string? FriendId { get; set; }
        public string? FriendUserName { get; set; }
        //public string? FriendUrl { get; set; }
        public bool IsFriend { get; set; }
        public bool IsSendRequest { get; set; }
        public UserFriendAvatarDto? avatar { get; set; }
    }

    public class FriendDtoViewModel : BaseDto
    {
        public string? UserId { get; set; }
        public string? FriendId { get; set; }
        public string? FriendUserName { get; set; }
        //public string? FriendUrl { get; set; }
        public bool IsSendRequest { get; set; }
        public bool IsFriend { get; set; }
        public string? avatar { get; set; }
    }

    public class UserFriendFilterData : BaseDto
    {
    }

    public class UserFriendFilterParam : BaseFilterParam
    {
        public string? UserName { get; set; }
    }

    public class UserFriendFilterResult : BaseFilter<FriendDto, UserFriendFilterParam>
    {
    }

    public class UserFriendFilterResultViewModel : BaseFilter<FriendDtoViewModel, UserFriendFilterParam>
    {
    }

    public class FriendData : BaseDto
    {
        public string Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public UserFriendAvatarDto avatar { get; set; }
    }
}
