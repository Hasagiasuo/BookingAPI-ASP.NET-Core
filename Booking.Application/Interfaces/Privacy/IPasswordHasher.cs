namespace Booking.Application.Interfaces.Privacy;

public interface IPasswordHasher
{
  string Generate(string password);
  bool Compare(string password, string passwordHash);
}