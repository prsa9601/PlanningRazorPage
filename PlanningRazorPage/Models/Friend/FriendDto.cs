namespace PlanningRazorPage.Models.Friend
{
    public class FriendDto : BaseDto
    {
        public string UserId { get; set; }
        public string FriendId { get; set; }
        public string FriendUserName { get; set; }
        public string FriendUrl { get; set; }
    }
}
