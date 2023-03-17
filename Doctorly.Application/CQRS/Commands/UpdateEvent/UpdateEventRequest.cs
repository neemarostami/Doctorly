using MediatR;

namespace Doctorly.Application.CQRS.Commands.UpdateEvent
{
    public class UpdateEventRequest : IRequest<bool>
    {
        public long EventId { get; set; }
        public long AttendeeId { get; set; }
        public string EventTitle { get; set; } = string.Empty;
        public string EventDescription { get; set; } = string.Empty;
        public DateOnly EventDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
