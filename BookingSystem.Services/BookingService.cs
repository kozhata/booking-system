using BookingSystem.Contracts;
using BookingSystem.Domain;

namespace BookingSystem.Services
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IUnitOfWork unitOfWork, IBookingRepository bookingRepository)
        {
            _unitOfWork = unitOfWork;
            _bookingRepository = bookingRepository;
        }

        public async Task CreateBooking(BookingRequest bookingRequest)
        {
            var newBooking = Booking.Create(
                name: bookingRequest.Name,
                createdOn: DateTime.UtcNow,
                email: bookingRequest.Email,
                flexibility: bookingRequest.Flexibility,
                vehicleSize: bookingRequest.VehicleSize,
                contactNumber: bookingRequest.ContactNumber);

            _bookingRepository.Insert(newBooking);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateBooking(int bookingId, BookingRequest bookingRequest)
        {
            var booking = await _bookingRepository.GetBookingAsync(bookingId);

            booking!.Update(
                name: bookingRequest.Name,
                email: bookingRequest.Email,
                flexibility: bookingRequest.Flexibility,
                vehicleSize: bookingRequest.VehicleSize,
                contactNumber: bookingRequest.ContactNumber);

            _bookingRepository.Update(booking!);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}