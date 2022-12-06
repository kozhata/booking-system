using BookingSystem.Contracts;
using BookingSystem.Domain;

using MediatR;

namespace BookingSystem.Services
{
    public class CreateBookingCommandHandler : AsyncRequestHandler<CreateBookingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookingRepository _bookingRepository;

        public CreateBookingCommandHandler(IUnitOfWork unitOfWork, IBookingRepository bookingRepository)
        {
            _unitOfWork = unitOfWork;
            _bookingRepository = bookingRepository;
        }

        protected override async Task Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var newBooking = Booking.Create(
                name: request.Request.Name,
                createdOn: DateTime.UtcNow,
                email: request.Request.Email,
                flexibility: request.Request.Flexibility,
                vehicleSize: request.Request.VehicleSize,
                contactNumber: request.Request.ContactNumber);

            _bookingRepository.Insert(newBooking);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
