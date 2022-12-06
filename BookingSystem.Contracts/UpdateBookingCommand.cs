using MediatR;

namespace BookingSystem.Contracts
{
    public class UpdateBookingCommand : IRequest
    {
        public UpdateBookingCommand(int bookingId, BookingRequest request)
        {
            Request = request;
            BookingId = bookingId;
        }

        public int BookingId { get; }

        public BookingRequest Request { get; }
    }
}
