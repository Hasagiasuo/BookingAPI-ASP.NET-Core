using Booking.Application.Interfaces.Privacy;
using Booking.Application.Interfaces.Repositories;
using Booking.Application.Mapping;
using Booking.Application.Services;
using Booking.Infrastructure.Context;
using Booking.Infrastructure.Privacy;
using Booking.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 

namespace Booking.Infrastructure.Configurations.Extensions;

public static class LayersExtension
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<BookingDbContext>(options =>
      options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
    
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IRoleRepository, RoleRepository>();
    services.AddScoped<IRoomRepository, RoomRepository>();
    services.AddScoped<IReservationRepository, ReservationRepository>();
    
    services.AddScoped<IJwtGenerator, JwtGenerator>();
    services.AddScoped<IPasswordHasher, PasswordHasher>();

    
    return services;
  }

  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddScoped<UserService>();
    services.AddScoped<RoleService>();
    services.AddScoped<RoomService>();
    services.AddScoped<ReservationService>();

    services.AddAutoMapper(
      typeof(UserProfile).Assembly,
      typeof(RoleProfile).Assembly,
      typeof(RoomProfile).Assembly,
      typeof(ReservationProfile).Assembly
    );

    return services; 
  }
}