using MediatR;

namespace BookingSystem.Contracts
{
    public class CreateBookingCommand : IRequest
    {
        public CreateBookingCommand(BookingRequest request)
        {
            Request = request;
        }

        public BookingRequest Request { get; }
    }
}
