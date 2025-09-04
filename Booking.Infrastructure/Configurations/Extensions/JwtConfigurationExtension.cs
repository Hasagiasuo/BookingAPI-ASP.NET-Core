using System.Text;
using Microsoft.Extensions.Configuration;
using Booking.Application.Configuration.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Booking.Infrastructure.Configurations.Extensions;

public static class JwtConfigurationExtension
{
  public static IServiceCollection AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
  {
    JwtSetting? jwtSetting = configuration.GetSection("JwtConfig").Get<JwtSetting>();
    if (jwtSetting == null) throw new Exception("JWT configuration section not found");
    services.AddAuthentication(options =>
    {
      options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
      options.TokenValidationParameters = new TokenValidationParameters()
      {
        ValidateIssuer = true,
        ValidIssuer = jwtSetting!.Issuer,
        ValidateAudience = true,
        ValidAudience = jwtSetting.Audience,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
          Encoding.UTF8.GetBytes(jwtSetting.Secret)) 
      };
      options.Events = new JwtBearerEvents()
      {
        OnMessageReceived = context =>
        {
          if (context.Request.Cookies.ContainsKey("satisfy"))
          {
            context.Token = context.Request.Cookies["satisfy"];
          }

          return Task.CompletedTask;
        }
      };
    });
    services.Configure<JwtSetting>(configuration.GetSection("JwtConfig"));
    return services;
  } 
}