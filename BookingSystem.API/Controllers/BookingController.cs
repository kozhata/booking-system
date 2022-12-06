using Microsoft.AspNetCore.Mvc;

using BookingSystem.Contracts;

namespace BookingSystem.API.Controllers
{
    [ApiController]
    [Route("api/booking")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        [Route("create")]
        public async Task CreateAsync([FromBody] BookingRequest bookingRequest)
        {
            await _bookingService.CreateBooking(bookingRequest);
        }

        [HttpPatch]
        [Route("{bookingId:int}/update")]
        public async Task UpdateAsync([FromRoute] int bookingId, [FromBody] BookingRequest bookingRequest)
        {
            await _bookingService.UpdateBooking(bookingId, bookingRequest);
        }
    }
}