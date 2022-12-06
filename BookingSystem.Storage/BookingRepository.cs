namespace BookingSystem.Storage
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    using BookingSystem.Domain;
    using BookingSystem.Contracts;

    public class BookingRepository : IBookingRepository
    {
        private readonly BookingSystemDbContext _bookingSystemDbContext;

        public BookingRepository(BookingSystemDbContext bookingSystemDbContext)
        {
            _bookingSystemDbContext = bookingSystemDbContext;
        }

        public Task<Booking?> GetBookingAsync(int bookingId)
        {
            return _bookingSystemDbContext.Set<Booking>()
                .AsNoTracking().FirstOrDefaultAsync(x => x.Id == bookingId);
        }

        public void Insert(Booking booking)
        {
            _bookingSystemDbContext.Set<Booking>().Add(booking);
        }

        public void Update(Booking booking)
        {
            _bookingSystemDbContext.Set<Booking>().Update(booking);
        }
    }
}
