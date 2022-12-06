using Microsoft.EntityFrameworkCore;

using BookingSystem.Contracts;
using BookingSystem.Services;
using BookingSystem.Storage;
using MediatR;
using BookingSystem.Queries;

namespace BookingSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<Storage.BookingSystemDbContext>(options =>
            {
                options.UseSqlServer("data source=(localdb)\\MSSQLLocalDB;integrated security=True;initial catalog=BookingSystem",
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(15),
                    errorNumbersToAdd: null);
                });
            });

            // Only read only intent
            builder.Services.AddDbContext<Queries.BookingSystemDbContext>(options =>
            {
                options.UseSqlServer("data source=(localdb)\\MSSQLLocalDB;integrated security=True;initial catalog=BookingSystem;applicationIntent=ReadOnly",
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(15),
                    errorNumbersToAdd: null);
                });
            });

            builder.Services.AddScoped<IBookingRepository, BookingRepository>();
            builder.Services.AddScoped<IUnitOfWork>(p => p.GetRequiredService<Storage.BookingSystemDbContext>());

            builder.Services.AddMediatR(typeof(CommandMarker).Assembly, typeof(QueryMarker).Assembly);

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}