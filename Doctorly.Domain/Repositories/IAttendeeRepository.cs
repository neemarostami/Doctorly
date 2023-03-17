using Doctorly.Domain.AggregatesModel.AttendeeAggregate;

namespace Doctorly.Domain.Repositories
{
    public interface IAttendeeRepository
    {
        Task<long> CreateAttendeeAsync(Attendee attendee);
    }
}
