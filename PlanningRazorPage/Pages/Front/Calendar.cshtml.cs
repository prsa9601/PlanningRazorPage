using System.Globalization;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Infrastructure.Utils;
using PlanningRazorPage.Models.Event;
using PlanningRazorPage.Models.Friend;
using PlanningRazorPage.Services.Event;
using PlanningRazorPage.Services.Friend;

namespace PlanningRazorPage.Pages.Front
{
    [BindProperties]
    public class IndexModel : BaseRazorPage
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IEventService _service;
        private readonly IFriendService _friendService;
        public IndexModel(ILogger<IndexModel> logger, IEventService service, IFriendService friendService)
        {
            _logger = logger;
            _service = service;
            _friendService = friendService;
        }

        public string Title { get; set; }
        public string StartTime { get; set; } 
        public string EndTime { get; set; } 
        public string Description { get; set; }
        public string Link { get; set; } 
        public string EventAddress { get; set; } 
        public bool AccessNotification { get; set; }

        public Tagged Tag { get; set; } 
        public List<string>? FriendUserNames { get; set; }
        public List<SearchFriendDto?> FriendResult { get; set; }
        public List<EventDtoViewModel?> EventDto { get; set; }
        //public Notification Notification { get; set; }
        //public long id { get; set; }
        public async Task OnGet(CancellationToken cancel)
        {  

            var friends = await _friendService.SearchFriendForEvent(
                new SearchFriendForEventFilterParamModel()
                {
                    Take = 1999, 
                    PageId = 1,
                    UserName = "p"
                });

            FriendResult = MapFriend(friends, cancel);
            var eventDto = await _service.GetByUserId();
            EventDto = MapEvent(eventDto, cancel);
            //foreach (var item in EventDto)
            //{
            //    item.Link = FormatDateTime(item.EndTime);
            //}
        }
        public async Task OnGetEvents(CancellationToken cancel)
        {  

            var friends = await _friendService.SearchFriendForEvent(
                new SearchFriendForEventFilterParamModel()
                {
                    Take = 1999, 
                    PageId = 1,
                    UserName = "p"
                });

            FriendResult = MapFriend(friends, cancel);
            var eventDto = await _service.GetByUserId();
            EventDto = MapEvent(eventDto, cancel);
            await Task.Delay(7000);
            //foreach (var item in EventDto)
            //{
            //    item.Link = FormatDateTime(item.EndTime);
            //}
        }
        private static string FormatDateTime(DateTime dateTime)
        {
            string dayOfWeek = dateTime.ToString("ddd", new CultureInfo("en-US"));
            string month = dateTime.ToString("MMM", new CultureInfo("en-US"));
            string day = dateTime.Day.ToString("00");
            string year = dateTime.Year.ToString();
            string time = dateTime.ToString("HH:mm:ss");
            string timeZone = dateTime.ToString("zzz");
            return $"{dayOfWeek} {month} {day} {year} {time} GMT{timeZone} (Iran Standard Time)";
        }
        //public async Task<List<EventDto?>> OnGetEvents(CancellationToken cancel)
        //{
        //    return await _service.GetByUserId();
        //}
        public async Task<IActionResult> OnPost()
        {

            var result = await _service.Add(new AddEventCommand()
            {
                accessNotification = AccessNotification,
                Description = Description,
                EndTime = EndTime.ToMiladi(),
                Link = Link,
                EventAddress = EventAddress,
                //notification = Notification,
                StartTime = StartTime.ToMiladi(),
                tag = Tag,
                Title = Title,
                //  userNames = FriendResult
            });
            return Page();
        }
        public async Task<IActionResult> OnPostCreateEvent(string title,
            DateTime startTime, DateTime endTime, string link, string eventAddress, 
            string tag, string description, string[] friendUserNames, bool accessNotification, 
            string notification)
        {
            var notificationEnum = NotificationEnum.none;
            switch (notification)
            {
                case "Sms":
                    notificationEnum = NotificationEnum.Sms;
                    break;
                case "Email":
                    notificationEnum = NotificationEnum.Email;
                    break;
                default:
                    notificationEnum = NotificationEnum.none;
                    break;
            }
            var tagEnum = Tagged.Business;
            switch (notification)
            {
                case "Business":
                    tagEnum = Tagged.Business;
                    break;
                case "Personal":
                    tagEnum = Tagged.Personal;
                    break;
                case "Family":
                    tagEnum = Tagged.Family;
                    break;
                case "Holiday":
                    tagEnum = Tagged.Holiday;
                    break;
                default:
                    tagEnum = Tagged.ETC;
                    break;
            }
            
            var result = await _service.Add(new AddEventCommand()
            {
                accessNotification = accessNotification,
                Description = description,
                //EndTime = endTime,
                EndTime = endTime.ToString().ToMiladi(),
                Link = link,
                EventAddress = eventAddress,
                notification = notificationEnum,
                //StartTime = startTime,
                StartTime = startTime.ToString().ToMiladi(),
                tag = tagEnum,
                Title = title,
                userNames = friendUserNames.ToList()
            });
            return Page();
        }
        public async Task<IActionResult> OnPostEditeEvent(string title,
            DateTime startTime, DateTime endTime, string link, string eventAddress, 
            string tag, string description, string[] friendUserNames, bool accessNotification, 
            string notification)
        {
            var notificationEnum = NotificationEnum.none;
            switch (notification)
            {
                case "Sms":
                    notificationEnum = NotificationEnum.Sms;
                    break;
                case "Email":
                    notificationEnum = NotificationEnum.Email;
                    break;
                default:
                    notificationEnum = NotificationEnum.none;
                    break;
            }
            var tagEnum = Tagged.Business;
            switch (notification)
            {
                case "Business":
                    tagEnum = Tagged.Business;
                    break;
                case "Personal":
                    tagEnum = Tagged.Personal;
                    break;
                case "Family":
                    tagEnum = Tagged.Family;
                    break;
                case "Holiday":
                    tagEnum = Tagged.Holiday;
                    break;
                default:
                    tagEnum = Tagged.ETC;
                    break;
            }
            
            var result = await _service.Edit(new EditEventCommand()
            {
                accessNotification = accessNotification,
                Description = description,
                //EndTime = endTime,
                EndTime = endTime.ToString().ToMiladi(),
                Link = link,
                EventAddress = eventAddress,
                notification = notificationEnum,
                //StartTime = startTime,
                StartTime = startTime.ToString().ToMiladi(),
                tag = tagEnum,
                Title = title,
                userNames = friendUserNames.ToList()
            });
            return Page();
        }
        public async Task<IActionResult> OnPostEdit()
        {
            string startTime = StartTime;
            var result = await _service.Edit(new EditEventCommand()
            {
                accessNotification = AccessNotification,
                Description = Description,
                EndTime = EndTime.ToMiladi(),
                Link = Link,
                EventAddress = EventAddress,
                //notification = Notification,
                StartTime = startTime.ToGregorianDateTime(),
                tag = Tag,
                Title = Title,
                // userNames = FriendsUserNames,
                //  Id = id,
            });
            return Page();
        }
        //public async Task<IActionResult> OnPostDelete()
        //{
        //    var result = await _service.Delete(id);
        //    return Page();
        //} 
        private List<SearchFriendDto> MapFriend(SearchFriendForEventFilterResult model, CancellationToken cancel)
        {
            var result = new List<SearchFriendDto>();
            foreach (var item in model.Data)
            {
                cancel.ThrowIfCancellationRequested();
                StringBuilder stringBuilder = new StringBuilder();
                StringBuilder tagBuilder = new StringBuilder();

                switch (item.avatar.Avatar)
                {
                    case Avatar.Man:
                        stringBuilder.Append("Man.png");
                        break;
                    case Avatar.Woman:
                        stringBuilder.Append("Woman.png");
                        break;
                    case Avatar.Boy:
                        stringBuilder.Append("Boy.png");
                        break;
                    case Avatar.Girl:
                        stringBuilder.Append("Girl.png");
                        break;
                    default:
                        stringBuilder.Append("Default.png");
                        break;

                }
                switch (Tag)
                {
                    case Tagged.Business:
                        tagBuilder.Append("Business");
                        break;
                    case Tagged.Personal:
                        tagBuilder.Append("Personal");
                        break;
                    case Tagged.Family:
                        tagBuilder.Append("Family");
                        break;
                    case Tagged.Holiday:
                        tagBuilder.Append("Holiday");
                        break;

                    default:
                        tagBuilder.Append("ETC");
                        break;

                }
                result.Add(new SearchFriendDto()
                {
                    avatar = stringBuilder.ToString(),
                    CreationDate = item.CreationDate,
                    Id = item.Id,
                    UserName = item.UserName,
                    PhoneNumber = item.PhoneNumber,
                    tag = tagBuilder.ToString()

                });
            }

            return result;
        }
        private List<EventDtoViewModel?> MapEvent(List<EventDto?> model, CancellationToken cancel)
        {
            var result = new List<EventDtoViewModel>();
            foreach (var item in model)
            {
                cancel.ThrowIfCancellationRequested();
                //StringBuilder stringBuilder = new StringBuilder();
                StringBuilder tagBuilder = new StringBuilder();

                //switch (item.avatar.Avatar)
                //{
                //    case Avatar.Man:
                //        stringBuilder.Append("Man.png");
                //        break;
                //    case Avatar.Woman:
                //        stringBuilder.Append("Woman.png");
                //        break;
                //    case Avatar.Boy:
                //        stringBuilder.Append("Boy.png");
                //        break;
                //    case Avatar.Girl:
                //        stringBuilder.Append("Girl.png");
                //        break;
                //    default:
                //        stringBuilder.Append("Default.png");
                //        break;

                //}
                switch (Tag)
                {
                    case Tagged.Business:
                        tagBuilder.Append("Business");
                        break;
                    //case Avatar.Woman:
                    //    stringBuilder.Append("Woman.png");
                    //    break;
                    //case Avatar.Boy:
                    //    stringBuilder.Append("Boy.png");
                    //    break;
                    //case Avatar.Girl:
                    //    stringBuilder.Append("Girl.png");
                    //    break;
                    default:
                        tagBuilder.Append("Business");
                        break;

                }
                result.Add(new EventDtoViewModel()
                {
                    EndTime = FormatDateTime(item.EndTime),
                    StartTime = FormatDateTime(item.StartTime),
                    AccessNotification = item.AccessNotification,
                    EventAddress = item.EventAddress,
                    Description = item.Description,
                    Link = item.Link,
                    notification = item.notification,
                    Title = item.Title,
                    CreationDate = item.CreationDate,
                    Id = item.Id,
                    Tag = tagBuilder.ToString()

                });
            }

            return result;
        }
        
    }
}
