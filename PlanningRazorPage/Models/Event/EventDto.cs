namespace PlanningRazorPage.Models.Event
{
    public class EventDto : BaseDto
    {
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string EventAddress { get; set; }

        public Tagged tag { get; set; }
        public Notification notification { get; set; }
        //public List<UserEvent> Participants { get; private set; }

        public bool AccessNotification { get; set; } = true;
    }
    public class EventForShopDto : BaseDto
    {
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Tagged tag { get; set; }

    }
    public enum Tagged
    {
        Worked
    }
    public enum Notification
    {
        none,
        Email,
        Sms
    }
}
