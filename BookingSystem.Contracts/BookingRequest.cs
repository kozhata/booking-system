
using System.ComponentModel.DataAnnotations;

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

        [Required, StringLength(50)]
        public string Name { get; }

        [Required, StringLength(50)]
        public string Email { get; }

        [Required, StringLength(10)]
        public string Flexibility { get; }

        [Required, StringLength(10)]
        public string VehicleSize { get; }

        [Required, StringLength(20)]
        public string ContactNumber { get; }
    }
}
