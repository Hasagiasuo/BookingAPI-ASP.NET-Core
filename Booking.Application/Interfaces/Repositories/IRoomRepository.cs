using Booking.Domain.Models;

namespace Booking.Application.Interfaces.Repositories;

public interface IRoomRepository : IBaseRepository<Room>
{
  Task<Room?> GetByTitle(string title);
}