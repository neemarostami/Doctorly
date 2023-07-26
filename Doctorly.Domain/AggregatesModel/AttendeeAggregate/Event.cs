using Doctorly.Domain.Common;
using System.Runtime.CompilerServices;

namespace Doctorly.Domain.AggregatesModel.AttendeeAggregate
{
    public class Event : EntityBase
    {
        protected Event() { }

        public Event(string title, string description, TimeOnly startTime, TimeOnly endTime, DateOnly eventDate, long? id = null)
        {
            if (id != null)
            {
                Id = (long)id;
            }

            Title = title;
            Description = description;
            StartTime = startTime;
            EndTime = endTime;
            EventDate = eventDate;
            IsAttended = false;
        }

        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public DateOnly EventDate { get; private set; }
        public TimeOnly StartTime { get; private set; }
        public TimeOnly EndTime { get; private set; }
        public bool IsAttended { get; private set; }
        public virtual Attendee Attendee { get; private set; }
        public long AttendeeId { get; private set; }

        public void AcceptEvent()
        {
            IsAttended = true;
        }

        public void RejectEvent()
        {
            IsAttended = false;
        }

        public void ChangeEventDate(DateOnly date)
        {
            EventDate = date;
        }
    }
}
