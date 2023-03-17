namespace Doctorly.Application.CQRS.Queries.GetAllEventsByFilter
{
    public class GetAllEventsByFilterResponse
    {
        public long EventId { get; set; }
        public string EventTitle { get; set; } = string.Empty;
        public string EventDescription { get; set; } = string.Empty;
        public long AttendeeId { get; set; }
        public string AttendeeName { get; set; } = string.Empty;
        public string AttendeeEmail { get; set; } = string.Empty;
        public DateOnly EventDate { get; set; }
        public TimeOnly EventStartTime { get; set; }
        public TimeOnly EventEndTime { get; set; }
    }
}
