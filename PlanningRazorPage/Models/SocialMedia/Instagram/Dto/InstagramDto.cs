using PlanningRazorPage.Models.SocialMedia.Instagram.Post;
using PlanningRazorPage.Models.SocialMedia.Instagram.Story;

namespace PlanningRazorPage.Models.SocialMedia.Instagram.Dto
{
    public class InstagramDto : BaseDto
    {
        //Instagram
        public string accessToken { get; set; } //AccessToken Instagram
        public string UserName { get; set; }
        public string InstagramName { get; set; }
        public SendMethodInstagram SendMethod { get; set; }

    }
    public class InstagramFilterData : BaseDto
    {
        public string accessToken { get; set; } //AccessToken Instagram
        public List<StoryDto> Stories { get; set; } //token Telegram
        public List<PostFilterData.PostDto> Posts { get; set; } //token Telegram
        public SendMethodInstagram SendMethod { get; set; }
    }
    public class InstagramFilterParam : BaseFilterParam
    {
        public long Id { get; set; }
        public string? Search { get; set; } = "";
        public PostSearchOrderBy? SearchOrderBy { get; set; }
        public string? Title { get; set; }
    }
    public class InstagramFilterResult : BaseFilter<InstagramDto, InstagramFilterParam>
    {
    }

    public enum SendMethodInstagram
    {
        Post,
        Story
    }
    public enum PostSearchOrderBy
    {
        //visit,
        latest
    }
}
