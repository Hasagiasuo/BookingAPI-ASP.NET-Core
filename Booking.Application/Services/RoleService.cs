using AutoMapper;
using Booking.Application.Errors;
using Booking.Application.DTO;
using Booking.Domain.Models;
using Booking.Application.Interfaces.Repositories;

namespace Booking.Application.Services;

public class RoleService(IRoleRepository repository, IMapper mapper)
{
  private readonly IMapper _mapper = mapper;
  private readonly IRoleRepository _repository = repository;

  public async Task<Result<bool>> Create(RoleCreate dto)
  {
    bool res = await _repository.Add(_mapper.Map<Role>(dto));
    return !res ?
      Result<bool>.Fail(new DataBaseError("Cannot create role", "Role Table")) :
      Result<bool>.Ok(true);
  }

  public async Task<ICollection<Role>> GetAll()
  {
    return await _repository.GetAll();
  }

  public async Task<Result<bool>> DeleteByTitle(string title)
  {
    return await _repository.DeleteByTitle(title) ?
      Result<bool>.Ok(true) :
      Result<bool>.Fail(new DataBaseError("Cannot delete role", "Roles"));
  }
}