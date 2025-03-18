namespace PlanningRazorPage.Models.Event
{
 
    public class AddEventCommand 
    {
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string EventAddress { get; set; }
        public bool accessNotification { get; set; }

        public Tagged tag { get; set; }
        public List<string> userNames { get; set; }
        public NotificationEnum notification { get; set; }
    }
    public class EditEventCommand 
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string EventAddress { get; set; }
        public bool accessNotification { get; set; }

        public List<string> userNames { get; set; }
        public Tagged tag { get; set; }
        public NotificationEnum notification { get; set; }
    }
    public class DeleteEventCommand 
    {
        public long Id { get; set; }
    }
    public class SetDatesEventCommand 
    {
        public long Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
