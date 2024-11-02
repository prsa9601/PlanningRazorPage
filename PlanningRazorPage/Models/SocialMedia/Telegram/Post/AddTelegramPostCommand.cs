namespace PlanningRazorPage.Models.SocialMedia.Telegram.Post
{
    public class AddTelegramPostCommand
    {
    }

    public record class AddPostCommand(
        string TelegramId,
        DateTime dateOfPosting,
        string description,
        string link,
        string slug,
        IFormFile Image,
        string VideoName); 
    public class AddImageCommand 
    {
        public string TelegramId { get; set; }
        public IFormFile ImageFile { get; set; }
        public long ProductId { get; set; }
        public int Sequence { get; set; }
    }

    public record class EditPostCommand(
        string TelegramId,
        long PostId,
        DateTime DateOfPosting,
        string Description,
        string Link,
        string Slug,
        string VideoName,
        IFormFile Image);
    public class DeletePostCommand 
    {
        public String TelegramId { get; set; }
        public long PostId { get; set; }
    }
    public class SendImageToTelegramCommand
    {
        public string TelegramId { get; set; }
        public long PostId { get; set; }

    }
    public class RemoveImagePostCommand 
    {
        public string TelegramId { get; set; }
        public long PostId { get; set; }
        public long ImageId { get; set; }
    }
    public class SendMessageToTelegramCommand 
    {
        //public long id { get; set; }
        public string TelegramId { get; set; }
        public string token { get; set; }
        // public string imagePath { get; set; }
        public string caption { get; set; }
    }
    public class SetImageCommand 
    {
        public string TelegramId { get; set; }
        public IFormFile Image { get; set; }
        public long postId { get; set; }
    }
    public class SendVideoToTelegramCommand 
    {
        public string TelegramId { get; set; }
        public long PostId { get; set; }
        public int width { get; set; }
        public string token { get; set; }
        public int height { get; set; }
        public string videoCaption { get; set; }
        public string videoPath { get; set; }
        public string thumbnail { get; set; }
    }

}
