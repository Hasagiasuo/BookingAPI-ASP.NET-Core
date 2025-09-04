using AutoMapper;
using Booking.Application.DTO;
using Booking.Application.Errors;
using Booking.Application.Interfaces.Repositories;
using Booking.Domain.Models;

namespace Booking.Application.Services;

public class RoomService(IRoomRepository roomRepository, IMapper mapper)
{
  private readonly IRoomRepository _roomRepository = roomRepository;
  private readonly IMapper _mapper = mapper;

  public async Task<Result<bool>> Create(RoomCreate dto)
  {
    Room room = _mapper.Map<Room>(dto);
    if (await _roomRepository.Add(room)) return Result<bool>.Ok(true);
    else return Result<bool>.Fail(new DataBaseError("Cannot add room", "Rooms"));
  }
  public async Task<ICollection<Room>> GetAll()
  {
    return await _roomRepository.GetAll();
  }
}