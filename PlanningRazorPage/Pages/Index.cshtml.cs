using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.Utils;
using PlanningRazorPage.Models.Event;
using PlanningRazorPage.Services.Event;

namespace PlanningRazorPage.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IEventService _service;
        public IndexModel(ILogger<IndexModel> logger, IEventService service)
        {
            _logger = logger;
            _service = service;
        }

        public string Title { get; set; } 
        public string StartTime { get; set; } = new DateTime().ToString();
        public string EndTime { get; set; } = new DateTime().ToString();
        public string Description { get; set; } = "jhg";
        public string Link { get; set; } = "gg";
        public string EventAddress { get; set; } = "kjh";
        public bool AccessNotification { get; set; } = false;

        public Tagged Tag { get; set; } = Tagged.Worked;
        public List<string> UserNumber { get; set; } = new List<string>();
        public Notification Notification { get; set; } = Notification.Email;
        //public long id { get; set; }
        public void OnGet()
        {
            
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
                notification = Notification,
                StartTime = StartTime.ToMiladi(),
                tag = Tag,
                Title = Title,
                userNumber = UserNumber  
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
                notification = Notification,
                StartTime = startTime.ToGregorianDateTime(),
                tag = Tag,
                Title = Title,
                userNumber = UserNumber,
              //  Id = id,
            });
            return Page();
        }
        //public async Task<IActionResult> OnPostDelete()
        //{
        //    var result = await _service.Delete(id);
        //    return Page();
        //} 
    }
}
