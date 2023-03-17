using Doctorly.Application.CQRS.Commands.CreateAttendee;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Doctorly.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AttendeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create Attendee
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> CreateAttendee(CreateAttendeeRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}
