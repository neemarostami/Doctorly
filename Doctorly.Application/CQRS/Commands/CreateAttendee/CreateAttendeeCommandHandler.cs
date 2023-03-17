using Doctorly.Domain.AggregatesModel.AttendeeAggregate;
using Doctorly.Domain.Repositories;
using MediatR;

namespace Doctorly.Application.CQRS.Commands.CreateAttendee
{
    public class CreateAttendeeCommandHandler : IRequestHandler<CreateAttendeeRequest, long>
    {
        private readonly IAttendeeRepository _attendeeRepository;

        public CreateAttendeeCommandHandler(IAttendeeRepository attendeeRepository)
        {
            _attendeeRepository = attendeeRepository;
        }

        public async Task<long> Handle(CreateAttendeeRequest request, CancellationToken cancellationToken)
        {
            Attendee attendee = new(request.Name, new Email(request.Email));
            var id = await _attendeeRepository.CreateAttendeeAsync(attendee);

            return id;
        }
    }
}
