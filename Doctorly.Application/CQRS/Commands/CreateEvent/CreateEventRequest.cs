using MediatR;

namespace Doctorly.Application.CQRS.Commands.CreateEvent
{
    public class CreateEventRequest : IRequest<bool>
    {
        public long AttendeeId { get; set; }
        public string EventTitle { get; set; } = string.Empty;
        public string EventDescription { get; set; } = string.Empty;
        public DateOnly EventDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set;}
    }
}
