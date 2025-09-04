using AutoMapper;
using Booking.Application.DTO;
using Booking.Domain.Models;

namespace Booking.Application.Mapping;

public class ReservationProfile : Profile
{
  public ReservationProfile()
  {
    CreateMap<Reservation, ReservationResponce>()
      .ForCtorParam("Username", opt => opt.MapFrom(src => src.User.Username))
      .ForCtorParam("RoomTitle", opt => opt.MapFrom(src => src.Room.Title))
      .ForCtorParam("Start", opt => opt.MapFrom(src => src.Start))
      .ForCtorParam("End", opt => opt.MapFrom(src => src.End));
  }
}