namespace BookingSystem.Queries
{
    public class BookingDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public DateTime CreatedOn { get; set; }

        public string? Flexibility { get; set; }

        public string? VehicleSize { get; set; }

        public string? ContactNumber { get; set; }
    }
}
