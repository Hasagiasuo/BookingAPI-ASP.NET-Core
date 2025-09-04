using AutoMapper;
using Booking.Application.DTO;
using Booking.Domain.Models;

namespace Booking.Application.Mapping;

public class RoleProfile : Profile
{
  public RoleProfile()
  {
    // CreateMap<RoleCreate, Role>()
    //   .ForMember(x => x.Id, opt => opt.Ignore())
    //   .ForMember(x => x.Users, opt => opt.Ignore());
  } 
}