using Booking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Infrastructure.Configurations.ModelsConfiguration;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
  public void Configure(EntityTypeBuilder<Reservation> builder)
  {
    builder.HasKey(x => x.Id);
    builder.HasOne(x => x.User)
      .WithMany(x => x.Reservations)
      .HasForeignKey(x => x.UserId);
    builder.HasOne(x => x.Room)
      .WithMany(x => x.Reservations)
      .HasForeignKey(x => x.RoomId);
  }
}