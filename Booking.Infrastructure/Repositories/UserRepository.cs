using Booking.Domain.Models;
using Booking.Application.Interfaces.Repositories;
using Booking.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure.Repositories;

public class UserRepository(BookingDbContext dbContext) : IUserRepository
{
  private readonly BookingDbContext _context = dbContext;
  public async Task<bool> Add(User entity)
  {
    await _context.Users.AddAsync(entity); 
    return await _context.SaveChangesAsync() > 0;
  }

  public async Task<User?> GetById(Guid id)
  {
    return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
  }

  public async Task<ICollection<User>> GetAll()
  {
    return await _context.Users.Include(x => x.Role).ToListAsync();
  }

  public Task<User?> GetByUsername(string username)
  {
    return _context.Users.Include(x => x.Role).FirstOrDefaultAsync(u => u.Username == username);
  }
}