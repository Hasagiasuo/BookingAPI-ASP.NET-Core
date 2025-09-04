namespace Booking.Application.Interfaces.Repositories;

public interface IBaseRepository<T>
{
  Task<bool> Add(T entity);   
  Task<T?> GetById(Guid id);
  Task<ICollection<T>> GetAll();
}