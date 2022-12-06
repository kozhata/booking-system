namespace BookingSystem.Contracts
{
    using BookingSystem.Domain;

    public interface IBookingRepository
    {
        void Insert(Booking booking);

        void Update(Booking booking);

        Task<Booking?> GetBookingAsync(int bookingId);
    }
}