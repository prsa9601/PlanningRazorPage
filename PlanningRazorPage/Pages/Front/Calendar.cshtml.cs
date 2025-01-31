using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.Utils;
using PlanningRazorPage.Models.Event;
using PlanningRazorPage.Models.Friend;
using PlanningRazorPage.Services.Event;
using PlanningRazorPage.Services.Friend;

namespace PlanningRazorPage.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
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

        }
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
                //  userNumber = FriendResult
            });
            return Page();
        }
        public async Task<IActionResult> OnPostCreateEvent(string title,
            DateTime startTime, DateTime endTime, string link, string eventAddress, 
            string tag, string description, string[] friendUserNames, bool accessNotification, 
            string notification)
        {
            var notificationEnum = Notification.none;
            switch (notification)
            {
                case "Sms":
                    notificationEnum = Notification.Sms;
                    break;
                case "Email":
                    notificationEnum = Notification.Email;
                    break;
                default:
                    notificationEnum = Notification.none;
                    break;
            }
            var tagEnum = Tagged.Worked;
            switch (notification)
            {
                case "Worked":
                    tagEnum = Tagged.Worked;
                    break;
                //case "Email":
                //    tagEnum = Notification.Email;
                //    break;
                default:
                    tagEnum = Tagged.Worked;
                    break;
            }

            var result = await _service.Add(new AddEventCommand()
            {
                accessNotification = accessNotification,
                Description = description,
                EndTime = endTime.ToString().ToMiladi(),
                Link = link,
                EventAddress = eventAddress,
                notification = notificationEnum,
                StartTime = startTime.ToString().ToMiladi(),
                tag = tagEnum,
                Title = title,
                userNumber = friendUserNames.ToList()
            });
            return Page();
        }
        public async Task<IActionResult> OnPostCreateEventt()
        {

            var result = await _service.Add(new AddEventCommand()
            {
                //accessNotification = accessNotification,
                //Description = description,
                //EndTime = endTime.ToMiladi(),
                //Link = link,
                //EventAddress = eventAddress,
                ////notification = notification,
                //StartTime = startTime.ToMiladi(),
                ////tag = tag,
                //Title = title,
                //userNumber = friendUserNames
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
                // userNumber = FriendsUserNames,
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
                    case Tagged.Worked:
                        tagBuilder.Append("کسب و کار");
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
                        tagBuilder.Append("کسب و کار");
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
    }
}
