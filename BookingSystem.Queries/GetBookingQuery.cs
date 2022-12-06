using MediatR;

using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Queries
{
    public class GetBookingQuery : IRequest<BookingDto?>
    {
        public GetBookingQuery(int bookingId)
        {
            BookingId = bookingId;
        }

        public int BookingId { get; }
    }

    public class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, BookingDto?>
    {
        private readonly BookingSystemDbContext _bookingSystemDbContext;

        public GetBookingQueryHandler(BookingSystemDbContext bookingSystemDbContext)
        {
            _bookingSystemDbContext = bookingSystemDbContext;
        }

        public Task<BookingDto?> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            return _bookingSystemDbContext.Set<Booking>()
               .AsNoTracking().Select(x => new BookingDto
               {
                   Id = x.Id,
                   Name = x.Name,
                   Email = x.Email,
                   CreatedOn = x.CreatedOn,
                   Flexibility = x.Flexibility,
                   VehicleSize = x.VehicleSize,
                   ContactNumber = x.ContactNumber
               }).FirstOrDefaultAsync(x => x.Id == request.BookingId);
        }
    }
}
