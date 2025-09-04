using Booking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Infrastructure.Configurations.ModelsConfiguration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
  public void Configure(EntityTypeBuilder<Role> builder)
  {
    builder.HasKey(r => r.Id);
    builder
      .Property(x => x.Title)
      .IsRequired();
    builder.HasMany(r => r.Users)
      .WithOne(r => r.Role)
      .HasForeignKey(r => r.RoleId);
  }
}