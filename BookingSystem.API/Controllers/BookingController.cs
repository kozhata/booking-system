using Microsoft.AspNetCore.Mvc;

using BookingSystem.Contracts;
using MediatR;

namespace BookingSystem.API.Controllers
{
    [ApiController]
    [Route("api/booking")]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task CreateAsync([FromBody] BookingRequest bookingRequest)
        {
            await _mediator.Send(new CreateBookingCommand(bookingRequest));
        }

        [HttpPatch]
        [Route("{bookingId:int}/update")]
        public async Task UpdateAsync([FromRoute] int bookingId, [FromBody] BookingRequest bookingRequest)
        {
            await _mediator.Send(new UpdateBookingCommand(bookingId, bookingRequest));
        }
    }
}