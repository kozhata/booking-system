namespace BookingSystem.Contracts
{
    public interface IBookingService
    {
        Task CreateBooking(BookingRequest bookingRequest);

        Task UpdateBooking(int bookingId, BookingRequest bookingRequest);
    }
}
