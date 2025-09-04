using Booking.Domain.Models;

namespace Booking.Application.Interfaces.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
  Task<User?> GetByUsername(string username);
}