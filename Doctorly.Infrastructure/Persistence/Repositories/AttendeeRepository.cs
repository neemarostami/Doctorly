using Doctorly.Domain.AggregatesModel.AttendeeAggregate;
using Doctorly.Domain.Repositories;

namespace Doctorly.Infrastructure.Persistence.Repositories
{
    public class AttendeeRepository : IAttendeeRepository
    {
        private readonly DoctorlyDbContext _context;

        public AttendeeRepository(DoctorlyDbContext context)
        {
            _context = context;
        }

        public async Task<long> CreateAttendeeAsync(Attendee attendee)
        {
            await _context.Attendees.AddAsync(attendee);
            await _context.SaveChangesAsync();

            return attendee.Id;
        }
    }
}
