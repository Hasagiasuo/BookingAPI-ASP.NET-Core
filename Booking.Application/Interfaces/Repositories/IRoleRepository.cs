using Booking.Domain.Models;

namespace Booking.Application.Interfaces.Repositories;

public interface IRoleRepository : IBaseRepository<Role>
{
  Task<Role?> GetByTitle(string title);
  Task<bool> DeleteByTitle(string title);
}