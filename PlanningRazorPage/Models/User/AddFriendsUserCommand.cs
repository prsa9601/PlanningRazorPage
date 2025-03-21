namespace PlanningRazorPage.Models.User
{
    public record class AddFriendsUserCommand
    {
        public string FriendId { get; set; }
        public string CurrentUser { get; set; }
    }
    public record class RemoveFriendUserCommand 
    {
        public string FriendId { get; set; }
        public string UserId { get; set; }
    }
    public class SetUserRoleCommand 
    {
        public string userId { get; set; }
        public List<string> rolesId { get; set; }
    }
    public class ChangePhoneNumberConfirmedStatusCommand
    {
        public required string UserId { get; set; }
    }
    public class ChangeEmailConfirmedUserStatusCommand 
    {
        public required String UserId { get; set; }
    }
    public class ChangeActivityUserStatusCommand 
    {
        public required string UserId { get; set; }
    }
}
