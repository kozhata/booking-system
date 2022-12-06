namespace BookingSystem.Domain
{
    public partial class Booking
    {
        public static Booking Create(
            string name,
            string email,
            string flexibility,
            string vehicleSize,
            DateTime createdOn,
            string contactNumber)
        {

            return new Booking(
                name: name,
                email: email,
                createdOn: createdOn,
                flexibility: flexibility,
                vehicleSize: vehicleSize,
                contactNumber: contactNumber);
        }
    }
}
