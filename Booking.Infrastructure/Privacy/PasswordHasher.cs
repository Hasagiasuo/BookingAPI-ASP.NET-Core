using Booking.Application.Interfaces.Privacy;

namespace Booking.Infrastructure.Privacy;

public class PasswordHasher : IPasswordHasher
{
  public string Generate(string password)
  {
    return BCrypt.Net.BCrypt.EnhancedHashPassword(password); 
  }

  public bool Compare(string password, string passwordHash)
  {
    return BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
  }
}