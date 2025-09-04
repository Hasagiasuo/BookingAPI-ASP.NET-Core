using AutoMapper;
using Booking.Application.DTO;
using Booking.Domain.Models;

namespace Booking.Application.Mapping;

public class RoomProfile : Profile
{
  public RoomProfile()
  {
    // CreateMap<RoomCreate, Room>()
    //   .ForMember(x => x.Id, o => o.Ignore())
    //   .ForMember(x => x.Count, o => o.Ignore())
    //   .ForMember(x => x.Reservations, o => o.Ignore());
  }  
}