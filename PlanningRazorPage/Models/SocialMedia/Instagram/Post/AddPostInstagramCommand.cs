namespace PlanningRazorPage.Models.SocialMedia.Instagram.Post
{
    public class AddPostInstagramCommand 
    {
        public string InstagramId { get; set; } = string.Empty;
        public DateTime DateOfPosting { get; set; }
        public string Link { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public string VideoName { get; set; } = string.Empty;

    }
    public class AddImageCommand 
    {
        public IFormFile ImageFile { get; set; }
        public long ProductId { get; set; }
        public int Sequence { get; set; }
    }
    public class DeletePostCommand 
    {
        public long id { get; set; }
    }
    public class DeletePostInstagramCommand 
    {
        public long PostId { get; set; }
        public string UserName { get; set; }
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
        public long InstagramId { get; set; }
        public long PostId { get; set; }
        public long ImageId { get; set; }
    }
    public class EditPostInstagramCommand 
    {
        public long postId { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfPosting { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public string VideoName { get; set; }


    }
}
