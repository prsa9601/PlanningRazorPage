namespace PlanningRazorPage.Models.User.UserPackage
{
    public class SetUserPackageCommand
    {
        public long packageId { get; set; }
        public string packageTitle { get; set; }
        public TimeSpan expireTime { get; set; }
        public int AllowedSmsCount { get; set; }
        public int AllowedEmailCount { get; set; }
        public string userId { get; set; }
    }
    public class EditUserPackageCommand
    {
        public long packageId { get; set; }
        public string userId { get; set; }
    }
    public class DeActiveUserPackageCommand
    {
        public string userId { get; set; }
        public long packageId { get; set; }
    }
}
