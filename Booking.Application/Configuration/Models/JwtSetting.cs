namespace Booking.Application.Configuration.Models;

public class JwtSetting
{
  public string Issuer { get; set; } = null!;
  public string Secret { get; set; } = null!;
  public string Audience { get; set; } = null!;
  public int LifetimeDays { get; set; }
}