using Microsoft.EntityFrameworkCore;
using Booking.Domain.Models;
using Booking.Infrastructure.Configurations.ModelsConfiguration;

namespace Booking.Infrastructure.Context;

public class BookingDbContext(DbContextOptions<BookingDbContext> options) : DbContext(options: options)
{
  public DbSet<User> Users { get; set; } 
  public DbSet<Room> Rooms { get; set; }
  public DbSet<Role> Roles { get; set; }
  public DbSet<Reservation> Reservations { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new UserConfiguration());
    modelBuilder.ApplyConfiguration(new RoomConfiguration());
    modelBuilder.ApplyConfiguration(new RoleConfiguration());
    modelBuilder.ApplyConfiguration(new ReservationConfiguration());
  }
   
}