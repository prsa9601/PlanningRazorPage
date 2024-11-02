namespace PlanningRazorPage.Models.SocialMedia.Telegram
{

    public class TelegramDto : BaseDto
    {
        public string accessToken { get; set; } //AccessToken Telegram
        public string UserName { get; set; }
        public string TelegramName { get; set; }
        public SendMethodTelegram SendMethod { get; set; }
        public TelegramChannelMethod ChannelMethod { get; set; }

    }
    internal class TelegramFilterData : BaseDto
    {
        public string ChannelName { get; set; }
        public string UserName { get; set; }
        public TelegramChannelMethod ChannelMethod { get; set; }
        public SendMethodTelegram SendMethod { get; set; }

    }
    public class TelegramFilterParam : BaseFilterParam
    {
        public long Id { get; set; }
        public string? Search { get; set; } = "";
        public PostSearchOrderBy? SearchOrderBy { get; set; }
        public string? Title { get; set; }
    }
    public class TelegramFilterResult : BaseFilter<TelegramDto, TelegramFilterParam>
    {

    }

    //public enum TelegramChannelMethod
    //{
    //    Channel,
    //    Group
    //}
    public enum PostSearchOrderBy
    {
        //visit,
        latest
    }
    public enum SendMethodTelegram
    {
        SendImage,
        SendText,
        SendVideo
    }

    public enum TelegramChannelMethod
    {
        Channel,
        Group
    }
}
