namespace PlanningRazorPage.Models.Friend;

public class UserFriendAvatarDto : BaseDto
{
    public string? UserId { get; set; }
    public Avatar Avatar { get; set; } = Avatar.Default;
}
public class SearchFriendForEventData : BaseDto
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }

    public UserFriendAvatarDto avatar { get; set; }
}



public class SearchFriendDto : BaseDto
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }

    public string avatar { get; set; }
    public string tag { get; set; }
}



public class SearchFriendForEventFilterParamModel : BaseFilterParam
{
    public string? UserName { get; set; } = string.Empty;
}
public class SearchFriendForEventFilterResult : BaseFilter<SearchFriendForEventData, SearchFriendForEventFilterParamModel>
{
}