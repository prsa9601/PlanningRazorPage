namespace PlanningRazorPage.Models.User
{
    public class EditUserCommand
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string userName { get; set; }
        public string Family { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
    public class DeleteUserCommand 
    {
        public string Id { get; set; }
    }
    public class SetAvatarCommand 
    {
        public string UserName { get; set; }
        public string Avatar { get; set; }
    }
    public record class SetUserEventCommand
    {
        public List<long> eventsId { get; set; }
        public string userId { get; set; }

    }
    public class EditUserCommandForAdmin 
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string userName { get; set; }
        public string Family { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
