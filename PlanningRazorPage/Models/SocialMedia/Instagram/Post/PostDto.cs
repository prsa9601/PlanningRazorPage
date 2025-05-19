using PlanningRazorPage.Models.SocialMedia.Instagram.Dto;
using PlanningRazorPage.Models.SocialMedia.Instagram.Story;

namespace PlanningRazorPage.Models.SocialMedia.Instagram.Post
{
    public class PostFilterData
    {
        public class InstagramFilterData : BaseDto
        {
            public string accessToken { get; set; } //AccessToken Instagram
            public List<StoryDto> Stories { get; set; } //token Telegram
            public List<PostDto> Posts { get; set; } //token Telegram
            public SendMethodInstagram SendMethod { get; set; }
        }

        public class InstagramFilterParam : BaseFilterParam
        {
            public long Id { get; set; }
            public string? Search { get; set; } = "";
            public PostSearchOrderBy? SearchOrderBy { get; set; }
            public string? Title { get; set; }
        }

        public class InstagramFilterResult : BaseFilter<InstagramFilterData, InstagramFilterParam>
        {
        }

        public class InstagramPostFilterParam : BaseFilterParam
        {
            public required long InstagramId { get; set; }
            public string? Search { get; set; } = "";
            public PostSearchOrderBy? SearchOrderBy { get; set; }

        }
        //public class PostDto : BaseDto
        //{
        //    public DateTime DateOfPosting { get; set; }
        //    //public string Picture { get; private set; }
        //    public string Description { get; set; }
        //    public string ImageName { get; set; }
        //    public string InstagramUserName { get; set; } // UserName or PageName
        //    public string Link { get; set; }
        //    //public string Slug { get; set; }
        //    public bool IsSend { get; set; }
        //    public string postId { get; set; } //InstagramPostId OR TelegramPostId
        //    public List<PostVideoDto> Videos { get; set; }
        //    public List<PostImageDto> Images { get; set; }
        //}
        //public class InstagramPostFilterParam : BaseFilterParam
        //{
        //    public required string InstagramId { get; set; }
        //    public string? Search { get; set; } = "";
        //    public PostSearchOrderBy? SearchOrderBy { get; set; }

        //}
        //public class InstagramPostFilterResult : BaseFilter<PostDto, InstagramPostFilterParam>
        //{
        //}

        public class InstagramPostFilterResult : BaseFilter<InstagramPostFilterData, InstagramPostFilterParam>
        {
        }
        public class InstagramPostFilterData : BaseDto
        {
            public DateTime DateOfPosting { get; set; }
            //public string Picture { get; private set; }
            public string Description { get; set; }
            public string ImageName { get; set; }
            public string Link { get; set; }
            public string InstagramUserName { get; set; } // UserName or PageName
            public string? InstagramPostId { get; set; } // UserName or PageName

            //public string Slug { get; set; }
            public bool IsSend { get; set; }
            public string postId { get; set; } //InstagramPostId OR TelegramPostId
            //public List<PostVideoDto> Videos { get; set; }
            public List<PostVideoDto> Videos { get; set; }
            //public List<PostImageDto> Images { get; set; }
        }
        public enum PostSearchOrderBy
        {
            //visit,
            latest
        }
        public class PostDto : BaseDto
        {
            public DateTime DateOfPosting { get; set; }
            //public string Picture { get; private set; }
            public string Description { get; set; }
            public string ImageName { get; set; }
            public string InstagramUserName { get; set; } // UserName or PageName
            public string Link { get; set; }
            //public string Slug { get; set; }
            public bool IsSend { get; set; }
            public string postId { get; set; } //InstagramPostId OR TelegramPostId
            public List<PostVideoDto> Videos { get; set; }
            //public List<PostImageDto> Images { get; set; }
        }
        public class PostImageDto : BaseDto
        {
            //public DateTime DateOfPosting { get;   set; }
            public string ImageName { get; set; }
            public long PostId { get; set; }
            public int Secuence { get; set; }
            public string Link { get; set; }
        }

        public class StoryImageDto : BaseDto
        {
            // public DateTime DateOfPosting { get; private set; }
            public string Picture { get; set; }
            public int Secuence { get; set; }
            public string Link { get; set; }
        }



        //public enum SendMedia
        //{
        //    Instagram,
        //    Telegram
        //}

        public class PostVideoDto : BaseDto
        {
            //public DateTime DateOfPosting { get; private set; }
            public string VideoName { get; set; }
            public long PostId { get; set; }
            public int Secuence { get; set; }
            public string Link { get; set; }

        }
        public class StoryVideoDto : BaseDto
        {
            // public DateTime DateOfPosting { get; private set; }
            public string VideoPath { get; set; }
            //public int Secuence { get; set; }
            public string Link { get; set; }

        }
    }
}
