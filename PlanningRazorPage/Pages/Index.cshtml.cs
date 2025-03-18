using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.Utils;
using PlanningRazorPage.Models.Event;
using PlanningRazorPage.Models.Friend;
using PlanningRazorPage.Services.Event;
using System.Globalization;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlanningRazorPage.Services.Friend;
using PlanningRazorPage.Services.Notification;
using PlanningRazorPage.Models.Notification;

namespace PlanningRazorPage.Pages
{
    public class IndexModel : PageModel
    {
        public IEventService _service { get; set; }
        public INotificationService _notificationService { get; set; }
        public IFriendService _friendService { get; set; }
        public IndexModel(IEventService service, IFriendService friendService, INotificationService notificationService)
        {
            _service = service;
            _friendService = friendService;
            _notificationService = notificationService;
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
        public List<SearchFriendDto>? FriendResult { get; set; }
        public List<EventDtoViewModel>? EventDto { get; set; }


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
        public async Task<IActionResult> OnGetEvents(CancellationToken cancel)
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
            //await Task.Delay(7000);
            //foreach (var item in EventDto)
            //{
            //    item.Link = FormatDateTime(item.EndTime);
            //}
            // Transform EventDto to FullCalendar format
            var calendarEvents = EventDto.Select(e => new
            {
                id = e.Id,
                url = e.Link,
                title = e.Title,
                start = e.StartTime,
                end = e.EndTime,
                allDay = false, // Adjust this according to your requirements
                extendedProps = new
                {
                    calendar = e.Tag
                }
            }).ToList();

            return new JsonResult(calendarEvents);
        }

        public async Task<IActionResult> OnPostUpdateEventDate(long id, DateTime newStart, DateTime newEnd)
        {
            var result = await _service.SetDates(new SetDatesEventCommand()
            {
                Id = id,
                StartTime = newStart,
                EndTime = newEnd
            });
            await _notificationService.ChangeDate(new ChangeDateNotificationCommand
            {
                EventId = id,
                SendTime = newStart,
                StartTime = newStart,
                EndTime = newEnd,
            });
            return new JsonResult(new { success = true });
        }
        public async Task<IActionResult> OnPostDeleteEvent(long id)
        {
            await _service.Delete(id);
            var result = await _notificationService.Remove(new Models.Notification.RemoveNotificationCommand
            {
                EventId = id
            });
            return new JsonResult(result.MetaData.Message);
        }
        public async Task<IActionResult> OnPostAdd(string title,
            DateTime startTime, DateTime endTime, string link, string eventAddress,
            string tag, string description, string[] friendUserNames, bool accessNotification,
            string[] notification, CancellationToken cancel)
        {
            NotificationEnum notificationEnum = new NotificationEnum();
            foreach (var item in notification)
            {
                if (item == "Sms")
                {
                    notificationEnum |= NotificationEnum.Sms;
                }
                if (item == "Email")
                {
                    notificationEnum |= NotificationEnum.Email;
                }
            }
            var notificationType = NotificationType.None;
            foreach (var item in notification) 
            {
                if (item=="Sms") 
                {
                    notificationType |= NotificationType.Sms;
                }
                if (item=="Email") 
                {
                    notificationType |= NotificationType.Email;
                }
            }
          
            var tagEnum = Tagged.Business;
            switch (tag)
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
                case "ETC":
                    tagEnum = Tagged.ETC;
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
            //if (accessNotification = Notification.Email)
            //{
            //long f = result.Data;
            var AddNotificationResult = await _notificationService.Add(new Models.Notification.AddNotificationViewModel
            {
                EventId = result.Data,
                SendTime = startTime.ToString().ToMiladi(),
                EventStartTime = startTime.ToString().ToMiladi(),
                NotificationType = notificationType,
                UserIds = friendUserNames.ToList(),
            });
            //OnGetEvents(cancel);
            return new JsonResult(AddNotificationResult.MetaData.Message);
        }
      
        #region Edit Event
        public async Task<IActionResult> OnPostEditEvent(string title,
                  DateTime startTime, DateTime endTime, string link, string eventAddress,
                  string tag, string description, string[] friendUserNames, bool accessNotification,
                  string[] notification, long id)
        {
            var notificationEnum = NotificationEnum.none;
            foreach (var item in notification)
            {
                if (item == "Sms")
                {
                    notificationEnum |= NotificationEnum.Sms;
                }
                if (item == "Email")
                {
                    notificationEnum |= NotificationEnum.Email;
                }
                if (item == "None")
                {
                    notificationEnum |= NotificationEnum.none;
                }
            }
            var notificationType = NotificationType.None;
            foreach (var item in notification)
            {
                if (item == "Sms")
                {
                    notificationType = NotificationType.Sms;
                }
                if (item == "Email")
                {
                    notificationType = NotificationType.Email;
                }
                if (item == "None")
                {
                    notificationType = NotificationType.None;
                }
            }

            var tagEnum = Tagged.Business;
            switch (tag)
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
                Id = id,
                userNames = friendUserNames.ToList()
            });
            var editNotificationResult = await _notificationService.Edit(new EditNotificationViewModel()
            {
                EventId = result.Data,
                EventEndTime = endTime.ToString().ToMiladi(),
                EventStartTime = startTime.ToString().ToMiladi(),
                NotificationType = notificationType,
                SendTime = startTime.ToString().ToMiladi(),
                UserNames = friendUserNames.ToList(),
            });
            return new JsonResult(editNotificationResult.MetaData.Message);
        }
        #endregion

        private static string FormatDateTime(DateTime dateTime)
        {
            string dayOfWeek = dateTime.ToString("ddd", new CultureInfo("en-US"));
            string month = dateTime.ToString("MMM", new CultureInfo("en-US"));
            string day = dateTime.Day.ToString("00");
            string year = dateTime.Year.ToString();
            string time = dateTime.ToString("HH:mm:ss");
            string timeZone = dateTime.ToString("zzz");/*{timeZone}*/
            return $"{dayOfWeek} {month} {day} {year} {time} GMT {timeZone} (Iran Standard Time)";
        }
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
                switch (item.tag)
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
                //tagBuilder.Clear();
            }

            return result;
        }

    }
}
