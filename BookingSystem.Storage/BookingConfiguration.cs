namespace BookingSystem.Storage
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using BookingSystem.Domain;

    internal class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Booking", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedOn).HasColumnName(@"CreatedOn").HasColumnType("smalldatetime").IsRequired();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(x => x.Flexibility).HasColumnName(@"Flexibility").HasColumnType("nvarchar(10)").IsRequired();
            builder.Property(x => x.VehicleSize).HasColumnName(@"VehicleSize").HasColumnType("nvarchar(10)").IsRequired();
            builder.Property(x => x.ContactNumber).HasColumnName(@"ContactNumber").HasColumnType("nvarchar(20)").IsRequired();
            builder.Property(x => x.Email).HasColumnName(@"Email").HasColumnType("nvarchar(50)").IsRequired();
        }
    }
}
