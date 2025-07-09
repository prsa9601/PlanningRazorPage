namespace PlanningRazorPage.Models.User.UserNotification
{
    public class UserNotificationDto : BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsSend { get; set; }
        public bool IsActive { get; set; }
        public bool IsSeen { get; set; }
        public DateTime SendTime { get; set; }
        public UserNotificationType SendType { get; set; }
        public string UserName { get; set; }
    }


    public class UserNotificationFilterDataDto : BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsSend { get; set; }
        public DateTime SendTime { get; set; }
        public UserNotificationType SendType { get; set; }
        public bool IsActive { get; set; }
        public bool IsSeen { get; set; }
        public string UserName { get; set; }
    }
    public class UserNotificationFilterParam : BaseFilterParam
    {
        public string? Search { get; set; }
        public required string UserId { get; set; }
    }
    public class UserNotificationFilterResult
        : BaseFilter<UserNotificationFilterDataDto, UserNotificationFilterParam>
    {
    }


    //public class UserNotificationFilterDataDtoForAdmin : BaseDto
    //{
    //    public required string Title { get; set; }
    //    public required string Description { get; set; }
    //    public bool IsSend { get; set; }
    //    public bool IsActive { get; set; }
    //    public bool IsSeen { get; set; }
    //    public List<string> UserNames { get; set; }
    //}
    public class UserNotificationDtoForAdmin : BaseDto
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public bool IsSend { get; set; }
        public bool IsActive { get; set; }
        public DateTime SendTime { get; set; }
        public UserNotificationType SendType { get; set; }
        public bool IsSeen { get; set; }
        public List<string?> UserNames { get; set; }
    }
    public class UserNotificationFilterParamForAdmin : BaseFilterParam
    {
        public string? Search { get; set; }
        public bool? IsSend { get; set; }
    }
    public class UserNotificationFilterResultForAdmin
        : BaseFilter<UserNotificationDtoForAdmin, UserNotificationFilterParamForAdmin>
    {

    }
}
