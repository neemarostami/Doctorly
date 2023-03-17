using MediatR;

namespace Doctorly.Application.CQRS.Commands.DeleteEvent
{
    public class DeleteEventRequest : IRequest<bool>
    {
        public long EventId { get; set; }
    }
}
