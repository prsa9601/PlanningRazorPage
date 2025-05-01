namespace PlanningRazorPage.Models.SocialMedia.Instagram.Account
{
    public class AddInstagramAccountCommandViewModel
    {
        //public string InstagramId { get; set; } //InstagramAccountId
        //public string PageId { get; set; } //PageId
        public string accessToken { get; set; } //AccessToken Instagram
        public string InstagramUserName { get; set; } //AccessToken Instagram
        public IFormFile Profile { get; set; } //token Telegram
    }
    public class EditInstagramAccountCommand
    {
        public required long Id { get; set; }
        public string accessToken { get; set; } //AccessToken Instagram
        public string UserName { get; set; } //AccessToken Instagram
        public string UserId { get; set; }
        public IFormFile? Profile { get; set; } //token Telegram
    }
    public class DeleteInstagramAccountCommand 
    {
        public required long Id { get; set; }// TableId
    }
    public class SetProfileInstagramAccountCommand
    {
        public long Id { get; set; }
        public IFormFile Image { get; set; }
    }
}
