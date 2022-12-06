using MediatR;

using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Queries
{
    public class GetBookingsQuery : IRequest<BookingDto[]> { }

    public class GetBookingsQueryHandler : IRequestHandler<GetBookingsQuery, BookingDto[]>
    {
        private readonly BookingSystemDbContext _bookingSystemDbContext;

        public GetBookingsQueryHandler(BookingSystemDbContext bookingSystemDbContext)
        {
            _bookingSystemDbContext = bookingSystemDbContext;
        }

        public Task<BookingDto[]> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
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
               }).ToArrayAsync();
        }
    }
}
