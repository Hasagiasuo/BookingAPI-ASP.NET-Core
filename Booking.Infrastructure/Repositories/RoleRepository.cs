using Booking.Domain.Models;
using Booking.Application.Interfaces.Repositories;
using Booking.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure.Repositories;

public class RoleRepository(BookingDbContext context) : IRoleRepository
{
  private readonly BookingDbContext _context = context;
  public async Task<bool> Add(Role entity)
  {
    await _context.Roles.AddAsync(entity);
    return await _context.SaveChangesAsync() > 0; 
  }

  public async Task<Role?> GetById(Guid id)
  {
    return await _context.Roles.FirstOrDefaultAsync(x => x.Id == id); 
  }

  public async Task<ICollection<Role>> GetAll()
  {
    return await _context.Roles.ToListAsync();
  }

  public async Task<Role?> GetByTitle(string title)
  {
    return await _context.Roles.FirstOrDefaultAsync(x => x.Title == title);
  }

  public async Task<bool> DeleteByTitle(string title)
  {
    Role? role = await _context.Roles.FirstOrDefaultAsync(x => x.Title == title);
    if (role == null) return false;
    _context.Roles.Remove(role);
    return await _context.SaveChangesAsync() > 0;
  }
}