using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Booking.Application.Configuration.Models;
using Booking.Application.Interfaces.Privacy;
using Booking.Domain.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Booking.Infrastructure.Privacy;

public class JwtGenerator(IOptions<JwtSetting> jwtSetting) :  IJwtGenerator
{
  private readonly JwtSetting _jwtSetting = jwtSetting.Value;
  
  public string GenerateJwtToken(User user)
  {
    Claim[] claims = [ 
      new("role", user.Role.Title),
      new("username", user.Username)
    ];
    SigningCredentials signingCredentials = new(new SymmetricSecurityKey(
      Encoding.UTF8.GetBytes(_jwtSetting.Secret)), 
      SecurityAlgorithms.HmacSha256);
    JwtSecurityToken token = new(
      claims: claims,
      audience: _jwtSetting.Audience,
      issuer: _jwtSetting.Issuer,
      signingCredentials: signingCredentials,
      expires: DateTime.UtcNow.AddDays(_jwtSetting.LifetimeDays));
    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}