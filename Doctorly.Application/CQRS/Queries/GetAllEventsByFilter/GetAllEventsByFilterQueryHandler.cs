using Doctorly.Domain.AggregatesModel.AttendeeAggregate;
using Doctorly.Domain.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Doctorly.Application.CQRS.Queries.GetAllEventsByFilter
{
    public class GetAllEventsByFilterQueryHandler : IRequestHandler<GetAllEventsByFilterRequest, List<GetAllEventsByFilterResponse>>
    {
        private readonly IEventRepository _eventRepository;

        public GetAllEventsByFilterQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<List<GetAllEventsByFilterResponse>> Handle(GetAllEventsByFilterRequest request, CancellationToken cancellationToken)
        {
            List<GetAllEventsByFilterResponse> resultView = new();
            List<Attendee> attendeeEvents = await _eventRepository.GetAllEventsAsync();

            if (request.AttendeeId != null)
            {
                attendeeEvents = attendeeEvents.Where(a => a.Id == request.AttendeeId).ToList();
            }

            foreach (var attendee in attendeeEvents)
            {
                foreach (var eventObj in attendee.Events)
                {
                    resultView.Add(new GetAllEventsByFilterResponse
                    {
                        EventId = eventObj.Id,
                        EventDate = eventObj.EventDate,
                        EventStartTime = eventObj.StartTime,
                        EventEndTime = eventObj.EndTime,
                        EventTitle = eventObj.Title,
                        EventDescription = eventObj.Description,
                        AttendeeId = attendee.Id,
                        AttendeeName = attendee.Name,
                        AttendeeEmail = attendee.Email.Value,
                    });
                }
            }

            return resultView;
        }
    }
}
