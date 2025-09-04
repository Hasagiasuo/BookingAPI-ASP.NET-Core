using Booking.Application.Errors;
using Booking.Application.Interfaces.Repositories;
using AutoMapper;
using Booking.Application.DTO;
using Booking.Domain.Models;

namespace Booking.Application.Services;

public class ReservationService(
  IReservationRepository reservationRepository,
  IRoomRepository roomRepository,
  IUserRepository userRepository,
  IMapper mapper)
{
  private readonly IReservationRepository _reservationRepository = reservationRepository;
  private readonly IUserRepository _userRepository = userRepository;
  private readonly IRoomRepository _roomRepository = roomRepository;
  private readonly IMapper _mapper = mapper;

  public async Task<Result<bool>> Create(ReservationCreate dto, string username)
  {
    User? user = await _userRepository.GetByUsername(username);
    if (user == null) return Result<bool>.Fail(new DataBaseError("Not find user", "Users"));
    Room? room = await _roomRepository.GetByTitle(dto.RoomTitle);
    if (room == null) return Result<bool>.Fail(new DataBaseError("Not find room", "Rooms"));
    if (room.Capacity - room.Count < dto.Count) return Result<bool>.Fail(new ValidationError("Room is full", "Capacity"));
    room.Count += dto.Count;
    Reservation reservation = new()
    {
      User = user,
      UserId = user.Id,
      Room = room,
      RoomId = room.Id,
      Start = dto.Start,
      End = dto.End
    };
    if (reservation.Start > reservation.End) return Result<bool>.Fail(new ValidationError("Start reservation cannot be biggest than end", "start/end"));
    ICollection<Reservation> reservsCollection = await _reservationRepository.GetAll();
    List<Reservation> reservs = [.. reservsCollection.Where(old => reservation.Start < old.End && old.Start < reservation.End)];
    if (reservs.Count > 0) return Result<bool>.Fail(new IntervalShedulingError("This interval for this room is reserved"));
    if (!await _reservationRepository.Add(reservation)) Result<bool>.Fail(new DataBaseError("Cannot create reservation", "Reservations"));
    return Result<bool>.Ok(true);
  }
  public async Task<ICollection<ReservationResponce>> GetAll()
  {
    ICollection<Reservation> reservs = await _reservationRepository.GetAll();
    List<ReservationResponce> result = new(reservs.Count);
    foreach (Reservation reserv in reservs)
    {
      ReservationResponce tmp = _mapper.Map<ReservationResponce>(reserv);
      result.Add(tmp);
    }
    return result;
  }
  public async Task<Result<Reservation>> GetById(Guid id)
  {
    Reservation? reserv = await _reservationRepository.GetById(id);
    if (reserv == null) return Result<Reservation>.Fail(new DataBaseError("Cannot get reservation by id", "Reservation"));
    return Result<Reservation>.Ok(reserv!);
  }
}