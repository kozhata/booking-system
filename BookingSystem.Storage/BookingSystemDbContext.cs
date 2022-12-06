namespace BookingSystem.Storage
{
    using BookingSystem.Contracts;

    using Microsoft.EntityFrameworkCore;

    public class BookingSystemDbContext : DbContext, IUnitOfWork
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