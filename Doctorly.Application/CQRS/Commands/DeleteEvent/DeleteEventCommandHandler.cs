using Doctorly.Domain.Repositories;
using MediatR;

namespace Doctorly.Application.CQRS.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventRequest, bool>
    {
        private readonly IEventRepository _eventRepository;

        public DeleteEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<bool> Handle(DeleteEventRequest request, CancellationToken cancellationToken)
        {
            await _eventRepository.DeleteOrCancelEventAsync(request.EventId);
            return true;
        }
    }
}
