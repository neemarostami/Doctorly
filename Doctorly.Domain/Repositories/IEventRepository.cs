using Doctorly.Domain.AggregatesModel.AttendeeAggregate;

namespace Doctorly.Domain.Repositories
{
    public interface IEventRepository
    {
        public Task<Attendee?> GetAttendeeByIdAsync(long id);
        public Task CreateEventAsync(Event eventObj);
        public Task UpdateEventAsync(Event eventObj);
        public Task DeleteOrCancelEventAsync(long eventId);
        public Task<Attendee?> GetEventsByAttendeeAsync(long attendeeId);
        public Task<List<Attendee>> GetAllEventsAsync();
        public Task<Event?> GetEventByIdAsync(long id);
    }
}
