using Doctorly.Application.CQRS.Commands.CreateEvent;
using Doctorly.Application.CQRS.Commands.DeleteEvent;
using Doctorly.Application.CQRS.Commands.UpdateEvent;
using Doctorly.Application.CQRS.Queries.GetAllEventsByFilter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Doctorly.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create Event for Attendee
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateEvent(CreateEventRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        /// <summary>
        /// Update Event
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateEvent(UpdateEventRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        /// <summary>
        /// Remove Event
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteEvent(DeleteEventRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        /// <summary>
        /// Get Events List by Special Filter
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetAllEventsByFilter(GetAllEventsByFilterRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}
