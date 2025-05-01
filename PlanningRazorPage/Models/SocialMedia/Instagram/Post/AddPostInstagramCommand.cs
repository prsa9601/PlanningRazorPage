namespace PlanningRazorPage.Models.SocialMedia.Instagram.Post
{
    public class AddPostInstagramCommand 
    {
        public long InstagramAccountId { get; set; } //TableId 
        public DateTime DateOfPosting { get; set; }
        public string Link { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<IFormFile>? Images { get; set; }
        public List<IFormFile>? Videos { get; set; }

    }
    public class EditPostInstagramCommand
    {
        public long postId { get; set; }
        public long InstagramAccountId { get; set; } //TableId 
        public DateTime DateOfPosting { get; set; }
        public string Link { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<IFormFile>? Images { get; set; }
        public List<IFormFile>? Videos { get; set; }
    }
    public record class CreateTelegramAccountCommand
        (string Token, string ChatId, string UserName, bool UsedDefaultToken);
    public record class EditTelegramAccountCommand(long TelegramId,
      string Token, string ChatId, string UserName, bool UsedDefaultToken);

    public class AddImageCommand
    {
        public long InstagramId { get; set; } // TableId
        public List<IFormFile> ImageFile { get; set; }
        public long PostId { get; set; } // TableId
    }
    public class DeletePostCommand 
    {
        public long id { get; set; }
    }
    public class DeletePostInstagramCommand 
    {
        public long InstagramId { get; set; }
        public long Id { get; set; }
    }
    public class SetImageCommand 
    {
        public string UserName { get; set; }
        public IFormFile ImageFile { get; set; }
        public long postId { get; set; }
    }
    public class SendToInstagramCommand 
    {
        public long PostId { get; set; }

    }
    public class RemoveImagePostCommand
    {
        public long InstagramId { get; set; } // TableId
        public long PostId { get; set; } // TableId
        public long ImageId { get; set; } // TableId
    }
}
