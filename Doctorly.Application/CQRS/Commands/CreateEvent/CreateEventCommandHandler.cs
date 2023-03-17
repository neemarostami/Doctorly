using Doctorly.Application.Services.Email;
using Doctorly.Domain.AggregatesModel.AttendeeAggregate;
using Doctorly.Domain.Repositories;
using MediatR;

namespace Doctorly.Application.CQRS.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventRequest, bool>
    {
        private readonly IEmailService _emailService;
        private readonly IEventRepository _eventRepository;

        public CreateEventCommandHandler(IEmailService emailService, IEventRepository eventRepository)
        {
            _emailService = emailService;
            _eventRepository = eventRepository;
        }

        public async Task<bool> Handle(CreateEventRequest request, CancellationToken cancellationToken)
        {
            Event eventObj = new(request.EventTitle, request.EventDescription, request.StartTime, request.EndTime, request.EventDate);
            Attendee? attendee = await _eventRepository.GetAttendeeByIdAsync(eventObj.AttendeeId);

            await _eventRepository.CreateEventAsync(eventObj);

            if (attendee != null)
            {
                // Send email to Attendee
                await _emailService.SendEmailAsync(attendee.Email.Value, "New Event",
                    $"Dear {attendee.Name}, a new appointment has been created for you!");
            }

            return true;
        }
    }
}
