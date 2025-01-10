namespace PlanningRazorPage.Models.Friend;

public class UserFriendAvatarDto : BaseDto
{
    public string? UserId { get; set; }
    public Avatar Avatar { get; set; } = Avatar.Default;
}