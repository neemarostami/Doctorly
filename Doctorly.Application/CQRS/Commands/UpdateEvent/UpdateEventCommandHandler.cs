using Doctorly.Domain.AggregatesModel.AttendeeAggregate;
using Doctorly.Domain.Repositories;
using MediatR;

namespace Doctorly.Application.CQRS.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventRequest, bool>
    {
        private readonly IEventRepository _eventRepository;

        public UpdateEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<bool> Handle(UpdateEventRequest request, CancellationToken cancellationToken)
        {
            Event eventObj = new Event(request.EventTitle, request.EventDescription, request.StartTime, request.EndTime, request.EventDate, request.EventId);
            await _eventRepository.UpdateEventAsync(eventObj);

            return true;
        }
    }
}
