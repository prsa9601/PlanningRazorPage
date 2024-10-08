namespace PlanningRazorPage.Models.SocialMedia.Instagram.Story
{
    public class AddStoryInstagramCommand
    {
    }
    public class SendToInstagramCommand
    {
        public string InstagramId { get; set; }
        public string AccessToken { get; set; }
        public string ImagePath { get; set; }
        public string Token { get; set; }
    }
    public class EditStoryCommand
    {
        public long InstagramId { get; set; }
        public long StoryId { get; set; }
        public DateTime DateOfPosting { get; set; }
        public string Link { get; set; }
        public IFormFile Image { get; set; }
    }
    public class DeleteStoryCommand 
    {
        public long id { get; set; }
        public long InstagramId { get; set; }
    }
    public class AddStoryCommand
    {
        public long InstagramId { get; set; }
        public DateTime DateOfPosting { get; set; }
        public string Link { get; set; }
        public IFormFile Image { get; set; }
    }
}
