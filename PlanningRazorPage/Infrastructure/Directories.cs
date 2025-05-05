namespace PlanningRazorPage.Infrastructure
{
    public class Directories
    {
        public const string ProductImages = "/images/products";
        public const string ArticleImages = "wwwroot/images/Article";

        public static string GetArticleImages(string imageName) => $"{ArticleImages.Replace("wwwroot", "")}/{imageName}";

        public const string ProductGalleryImage = "/images/products/gallery";

        public const string BannerImages = "/images/banners";
        public const string SliderImages = "/images/sliders";
        public const string InstagramPostImages = "/images/Instagram/Post/image";
        public const string InstagramPostVideos = "/images/Instagram/Post/Videos";
        public const string TelegramImages = "/images/Telegram/image";
        public const string TelegramVideo = "/images/Telegram/Videos";
        public const string InstagramStoryImages = "/images/Instagram/Story/image";
        public const string InstagramStoryVideos = "/images/Instagram/Story/Videos";
        public const string BlogImage = "/images/Blog/Images";
        public const string UserAvatars = "/images/users/avatar";
        public const string PackageImages = "/images/package/image";
        public const string InstagramProfile = "/images/Instagram/Profile";

        public static string GetInstagramAccountProfile(string imageName)
        {
            return $"{SiteSettings.ServerPath}{InstagramProfile}/{imageName}";
        }
        public static string GetInstagramPostImage(string imageName)
        {
            return $"{SiteSettings.ServerPath}{InstagramPostImages}/{imageName}";
        }
        public static string GetInstagramPostVideo(string imageName)
        {
            return $"{SiteSettings.ServerPath}{InstagramPostVideos}/{imageName}";
        }
        public static string GetInstagramStoryImage(string imageName)
        {
            return $"{SiteSettings.ServerPath}{InstagramStoryImages}/{imageName}";
        }
        public static string GetInstagramStoryVideo(string imageName)
        {
            return $"{SiteSettings.ServerPath}{InstagramStoryVideos}/{imageName}";
        }
        public static string GetTelegramImage(string imageName)
        {
            return $"{SiteSettings.ServerPath}{TelegramImages}/{imageName}";
        }
        public static string GetTelegramVideo(string imageName)
        {
            return $"{SiteSettings.ServerPath}{TelegramVideo}/{imageName}";
        }
        public static string GetPackageImage(string imageName)
        {
            return $"{SiteSettings.ServerPath}{PackageImages}/{imageName}";
        }
        public static string GetSliderImage(string imageName)
        {
            return $"{SiteSettings.ServerPath}{SliderImages}/{imageName}";
        }
        public static string GetAvatar(string imageName)
        {
            return $"{SiteSettings.ServerPath}{UserAvatars}/{imageName}.png";
        }
        public static string GetProductImage(string imageName)
        {
            return $"{SiteSettings.ServerPath}{ProductImages}/{imageName}";
        }
        public static string GetProductImageGallery(string imageName)
        {
            return $"{SiteSettings.ServerPath}{ProductGalleryImage}/{imageName}";
        }
        public static string GetBannerImage(string imageName)
        {
            return $"{SiteSettings.ServerPath}{BannerImages}/{imageName}";
        }

        public static string GetSliderImages(string imageName)
        {
            return $"{SiteSettings.ServerPath}{SliderImages}/{imageName}";

        }
    }
}