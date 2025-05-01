namespace PlanningRazorPage.Models.SocialMedia.Telegram.Post
{
    public class AddTelegramPostCommand
    {
    }

    public record class AddPostCommand(long TelegramId, DateTime dateOfPosting,
       string description, string? link, string slug,
       List<IFormFile> Images, List<IFormFile> Videos);
    public record class CreateTelegramAccountCommandViewModel(string? Token, string ChatId, bool UsedDefaultToken);
    public record class EditTelegramAccountCommand(long TelegramId,
    string Token, string ChatId, string UserName, bool UsedDefaultToken);
    public record class RemoveTelegramAccountCommand(long TelegramId);

    public class AddImageCommand 
    {
        public string TelegramId { get; set; }
        public IFormFile ImageFile { get; set; }
        public long ProductId { get; set; }
        public int Sequence { get; set; }
    }

    public record class EditPostCommand(long TelegramId, long PostId,
        DateTime DateOfPosting, string Description,
        string Slug, List<IFormFile> Videos, List<IFormFile> Images);

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
        public long TelegramId { get; set; }
        public List<ImageWithSequence> Images { get; set; }
        public long postId { get; set; }
        //public int Secuence { get; set; }
    }
    public class ImageWithSequence
    {
        public IFormFile File { get; set; }
        public int Sequence { get; set; }
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
