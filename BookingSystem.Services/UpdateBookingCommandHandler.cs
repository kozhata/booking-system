using BookingSystem.Contracts;

using MediatR;

namespace BookingSystem.Services
{  
    public class UpdateBookingCommandHandler : AsyncRequestHandler<UpdateBookingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookingRepository _bookingRepository;

        public UpdateBookingCommandHandler(IUnitOfWork unitOfWork, IBookingRepository bookingRepository)
        {
            _unitOfWork = unitOfWork;
            _bookingRepository = bookingRepository;
        }

        protected override async Task Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            // This needs to support not found/null and invalid state

            var booking = await _bookingRepository.GetBookingAsync(request.BookingId);

            booking!.Update(
                name: request.Request.Name,
                email: request.Request.Email,
                flexibility: request.Request.Flexibility,
                vehicleSize: request.Request.VehicleSize,
                contactNumber: request.Request.ContactNumber);

            _bookingRepository.Update(booking!);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
