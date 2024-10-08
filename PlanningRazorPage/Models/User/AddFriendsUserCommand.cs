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
}
