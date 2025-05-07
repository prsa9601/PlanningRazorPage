using PlanningRazorPage.Models.SocialMedia.Instagram.Dto;
using static PlanningRazorPage.Models.SocialMedia.Instagram.Post.PostFilterData;

namespace PlanningRazorPage.Models.SocialMedia.Instagram.Story
{
    public class StoryDto : BaseDto
    {
        public string storyId { get; set; } //InstagramPostId OR TelegramPostId

        public DateTime DateOfPosting { get; set; }
        public string Link { get; set; }
        public bool IsSend { get; set; }
        public string ImageName { get; set; }
        public string InstagramUserName { get; set; }
        public string VideoName { get; set; }
        public StoryImageDto Images { get; set; }
        public StoryVideoDto Videos { get; set; }
        public SendMethodInstagram SendMethod { get; set; }
    }

    public class StoryImageDto : BaseDto
    {
        // public DateTime DateOfPosting { get; private set; }
        public string PictureName { get; set; }
        // public long StoryId { get; set; }
        public string Link { get; set; }
    }

    public class StoryVideoDto : BaseDto
    {
        public string VideoPath { get; set; }
        public string Link { get; set; }
        //public long StoryId { get; set; }
    }

    internal class StoryFilterData : BaseDto
    {
    }
    public class InstagramPostFilterData : BaseDto
    {
        public string storyId { get; set; } //InstagramPostId OR TelegramPostId
        public DateTime DateOfPosting { get; set; }
        public string Link { get; set; }
        public bool IsSend { get; set; }
        public string ImageName { get; set; }
        public string InstagramUserName { get; set; } // UserName or PageName
        public string VideoName { get; set; }
        public StoryImageDto Images { get; set; }
        public StoryVideoDto Videos { get; set; }
        public SendMethodInstagram SendMethod { get; set; }
    }
    public class StoryFilterParam : BaseFilterParam
    {
        public required string InstagramId { get; set; }
        public string? Search { get; set; } = "";
        public StorySearchOrderBy? SearchOrderBy { get; set; }

    }
    public class StoryFilterResult : BaseFilter<StoryDto, StoryFilterParam>
    {
    }

    public enum StorySearchOrderBy
    {
        //visit,
        latest
    }
}
