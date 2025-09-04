using Booking.Domain.Models;

namespace Booking.Application.Interfaces.Privacy;

public interface IJwtGenerator
{
  string GenerateJwtToken(User user); 
}