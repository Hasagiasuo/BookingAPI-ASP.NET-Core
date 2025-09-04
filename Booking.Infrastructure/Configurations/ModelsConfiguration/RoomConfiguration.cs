using Booking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Infrastructure.Configurations.ModelsConfiguration;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
  public void Configure(EntityTypeBuilder<Room> builder)
  {
    builder.HasKey(r => r.Id);
    builder.HasMany(x => x.Reservations)
      .WithOne(r => r.Room)
      .HasForeignKey(r => r.RoomId);
    builder
      .Property(x => x.Title)
      .IsRequired();
  }
}