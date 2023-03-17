using MediatR;

namespace Doctorly.Application.CQRS.Queries.GetAllEventsByFilter
{
    public class GetAllEventsByFilterRequest : IRequest<List<GetAllEventsByFilterResponse>>
    {
        public long? AttendeeId { get; set; } = null;
    }
}
