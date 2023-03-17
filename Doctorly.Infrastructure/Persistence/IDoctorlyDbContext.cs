using Doctorly.Domain.AggregatesModel.AttendeeAggregate;
using Microsoft.EntityFrameworkCore;

namespace Doctorly.Infrastructure.Persistence
{
    public interface IDoctorlyDbContext
    {
        DbSet<Attendee> Attendees { get; set; }
        DbSet<Event> Events { get; set; }
        Task<int> SaveChangesAsync();
    }
}
