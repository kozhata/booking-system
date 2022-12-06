namespace BookingSystem.Domain
{
    public partial class Booking
    {
        public void Update(
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
    }
}
