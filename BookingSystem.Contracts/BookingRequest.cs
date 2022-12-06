
namespace BookingSystem.Contracts
{
    public class BookingRequest
    {
        public BookingRequest(
            string name,
            string email,
            string flexibility,
            string vehicleSize,
            string contactNumber)
        {
            Name = name;
            Email = email;
            Flexibility = flexibility;
            VehicleSize = vehicleSize;
            ContactNumber = contactNumber;
        }

        public string Name { get; }

        public string Email { get; }

        public string Flexibility { get; }

        public string VehicleSize { get; }

        public string ContactNumber { get; }
    }
}
