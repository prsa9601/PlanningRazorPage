namespace PlanningRazorPage.Models.User
{
    public class UserDto : BaseDto
    {
        public string Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public List<FriendsDto> friends { get; set; }
    }
    public class FriendsDto : BaseDto
    {
        public string CurrentUserId { get; set; }
        public string UserFriend { get; set; }
    }
}
