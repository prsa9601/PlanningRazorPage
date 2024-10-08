using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Models.Event;
using PlanningRazorPage.Services.Event;

namespace PlanningRazorPage.Pages
{
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
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string EventAddress { get; set; }
        public bool AccessNotification { get; set; }

        public Tagged Tag { get; set; }
        public List<string> UserNumber { get; set; }
        public Notification Notification { get; set; }
        public long id { get; set; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {

            var result = await _service.Add(new AddEventCommand()
            {
                accessNotification = AccessNotification,
                Description = Description,
                EndTime = EndTime,
                Link = Link,
                EventAddress = EventAddress,
                notification = Notification,
                StartTime = StartTime,
                tag = Tag,
                Title = Title,
                userNumber = UserNumber  
            });
            return Page();
        }
        public async Task<IActionResult> OnPostEdit()
        {

            var result = await _service.Edit(new EditEventCommand()
            {
                accessNotification = AccessNotification,
                Description = Description,
                EndTime = EndTime,
                Link = Link,
                EventAddress = EventAddress,
                notification = Notification,
                StartTime = StartTime,
                tag = Tag,
                Title = Title,
                userNumber = UserNumber,
                Id = id
            });
            return Page();
        }
        public async Task<IActionResult> OnPostDelete()
        {
            var result = await _service.Delete(id);
            return Page();
        } 
    }
}
