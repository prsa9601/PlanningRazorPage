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
}
