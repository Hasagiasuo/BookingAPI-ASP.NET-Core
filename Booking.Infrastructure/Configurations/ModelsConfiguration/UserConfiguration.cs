using Booking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Infrastructure.Configurations.ModelsConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.HasKey(x => x.Id);
    builder.HasMany(x => x.Reservations) 
      .WithOne(x => x.User)
      .HasForeignKey(x => x.UserId);
    builder
      .Property(x => x.Username)
      .IsRequired();
    builder
      .Property(x => x.PasswordHash) 
      .IsRequired();
    builder
      .Property(x => x.RoleId)
      .IsRequired();
    builder.HasOne(r => r.Role)
      .WithMany(r => r.Users)
      .HasForeignKey(r => r.RoleId);
  }
}