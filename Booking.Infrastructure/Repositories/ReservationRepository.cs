using Booking.Application.Interfaces.Repositories;
using Booking.Domain.Models;
using Booking.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure.Repositories;

public class ReservationRepository(BookingDbContext context) : IReservationRepository
{
  private readonly BookingDbContext _context = context;
  public async Task<bool> Add(Reservation entity)
  {
    await _context.Reservations.AddAsync(entity);
    return await _context.SaveChangesAsync() > 0;
  }

  public async Task<ICollection<Reservation>> GetAll()
  {
    return await _context.Reservations
      .Include(x => x.User)
      .Include(x => x.Room)
      .ToListAsync();
  }

  public async Task<Reservation?> GetById(Guid id)
  {
    return await _context.Reservations.FirstOrDefaultAsync(x => x.Id == id);
  }
}