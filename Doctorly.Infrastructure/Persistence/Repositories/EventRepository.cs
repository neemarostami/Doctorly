using Doctorly.Domain.AggregatesModel.AttendeeAggregate;
using Doctorly.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Doctorly.Infrastructure.Persistence.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly DoctorlyDbContext _context;

        public EventRepository(DoctorlyDbContext context)
        {
            _context = context;
        }

        public async Task CreateEventAsync(Event eventObj)
        {
            await _context.Events.AddAsync(eventObj);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrCancelEventAsync(long eventId)
        {
            var eventObj = await _context.Events.Where(p => p.Id == eventId).FirstOrDefaultAsync();
            if (eventObj != null)
            {
                _context.Events.Remove(eventObj);
            }
        }

        public async Task<List<Attendee>> GetAllEventsAsync()
        {
            return await _context.Attendees.Include(a => a.Events).ToListAsync();
        }

        public async Task<Attendee?> GetAttendeeByIdAsync(long id)
        {
            return await _context.Attendees.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Event?> GetEventByIdAsync(long id)
        {
            return await _context.Events.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Attendee?> GetEventsByAttendeeAsync(long attendeeId)
        {
            return await _context.Attendees.Include(a => a.Events).Where(a => a.Id == attendeeId).FirstOrDefaultAsync();
        }

        public async Task UpdateEventAsync(Event eventObj)
        {
            _context.Events.Update(eventObj);
            await _context.SaveChangesAsync();
        }
    }
}
