using MediatR;

namespace Doctorly.Application.CQRS.Commands.CreateAttendee
{
    public class CreateAttendeeRequest : IRequest<long>
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
