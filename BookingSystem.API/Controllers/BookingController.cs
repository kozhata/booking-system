using Microsoft.AspNetCore.Mvc;

using BookingSystem.Contracts;
using MediatR;
using BookingSystem.Queries;

namespace BookingSystem.API.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public Task CreateAsync([FromBody] BookingRequest bookingRequest)
        {
            return _mediator.Send(new CreateBookingCommand(bookingRequest));
        }

        [HttpPatch]
        [Route("{bookingId:int}/update")]
        public Task UpdateAsync([FromRoute] int bookingId, [FromBody] BookingRequest bookingRequest)
        {
            return _mediator.Send(new UpdateBookingCommand(bookingId, bookingRequest));
        }

        [HttpGet]
        [Route("{bookingId:int}")]
        public Task<BookingDto?> GetAsync([FromRoute] int bookingId)
        {
            return _mediator.Send(new GetBookingQuery(bookingId));
        }

        [HttpGet]
        [Route("list")]
        public Task<BookingDto[]> ListAsync()
        {
            return _mediator.Send(new GetBookingsQuery());
        }
    }
}