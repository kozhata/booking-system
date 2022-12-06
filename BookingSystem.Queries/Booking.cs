namespace BookingSystem.Queries
{
    public class Booking
    {
        public Booking(
            int id,
            string name,
            string email,
            string flexibility,
            string vehicleSize,
            DateTime createdOn,
            string contactNumber)
        {
            Id = id;
            Name = name;
            Email = email;
            CreatedOn = createdOn;
            Flexibility = flexibility;
            VehicleSize = vehicleSize;
            ContactNumber = contactNumber;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Flexibility { get; private set; }

        public string VehicleSize { get; private set; }

        public DateTime CreatedOn { get; private set; }

        public string ContactNumber { get; private set; }
    }
}