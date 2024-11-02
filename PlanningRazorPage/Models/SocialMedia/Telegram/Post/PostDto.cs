using static PlanningRazorPage.Models.SocialMedia.Instagram.Post.PostFilterData;

namespace PlanningRazorPage.Models.SocialMedia.Telegram.Post
{
    public class TelegramDto : BaseDto
    {
        //Telegram
        public string token { get; set; } //token Telegram
        public string chat_id { get; set; } //TelegramID
        public string UserName { get; set; } //token Telegram
        public List<PostDto> Posts { get; set; }

    }

    public class PostDto : BaseDto
    {
        public DateTime DateOfPosting { get; set; }
        //public string Picture { get; private set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public string Link { get; set; }
        public string TelegramUserName { get; set; } //channelAddress Or Group
        //public string Slug { get; set; }
        public bool IsSend { get; set; }
        public string postId { get; set; } //InstagramPostId OR TelegramPostId
        public List<PostImageDto> Images { get; set; }
        public List<PostVideoDto> Videos { get; set; }
    }
    public class PostImageDto : BaseDto
    {
        //public DateTime DateOfPosting { get; set; }
        public string ImageName { get; set; }
        public long PostId { get; set; }
        public int Secuence { get; set; }
        public string Link { get; set; }
    }
    public class PostVideoDto : BaseDto
    {
        //public DateTime DateOfPosting { get; set; }
        public string VideoName { get; set; }
        public long PostId { get; set; }
        public int Sequence { get; set; }
        public string Link { get; set; }

    }
    public class TelegramFilterData : BaseDto
    {
        public string token { get; set; } //token Telegram
        public string chat_id { get; set; } //TelegramID
        public string UserName { get; set; } //token Telegram
        public List<PostDto> Posts { get; set; }
    }
    public class TelegramFilterParam : BaseFilterParam
    {
        public long Id { get; set; }
        public string? Search { get; set; } = "";
        public TelegramSearchOrderBy? SearchOrderBy { get; set; }
        public string? Title { get; set; }
    }
    public class TelegramPostFilterResult : BaseFilter<PostDto, TelegramFilterParam>
    {
    }

    public enum TelegramSearchOrderBy
    {
        //visit,
        latest
    }
}
