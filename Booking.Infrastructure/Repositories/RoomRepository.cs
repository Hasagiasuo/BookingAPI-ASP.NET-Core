using Booking.Application.Interfaces.Repositories;
using Booking.Domain.Models;
using Booking.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure.Repositories;

public class RoomRepository(BookingDbContext context) : IRoomRepository
{
  private readonly BookingDbContext _context = context;
  public async Task<bool> Add(Room entity)
  {
    await _context.Rooms.AddAsync(entity);
    return await _context.SaveChangesAsync() > 0;
  }

  public async Task<ICollection<Room>> GetAll()
  {
    return await _context.Rooms
      .Include(x => x.Reservations)
      .ToListAsync();
  }

  public async Task<Room?> GetById(Guid id)
  {
    return await _context.Rooms.FirstOrDefaultAsync(x => x.Id == id);
  }

  public async Task<Room?> GetByTitle(string title)
  {
    return await _context.Rooms.FirstOrDefaultAsync(x => x.Title == title);
  }
}