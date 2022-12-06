namespace BookingSystem.Queries
{
    using Microsoft.EntityFrameworkCore;

    public class BookingSystemDbContext : DbContext
    {
        public BookingSystemDbContext(DbContextOptions<BookingSystemDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BookingConfiguration());
        }
    }
}