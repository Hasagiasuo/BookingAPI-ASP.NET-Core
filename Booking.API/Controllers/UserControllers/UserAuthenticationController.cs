using Microsoft.AspNetCore.Mvc;
using Booking.Application.DTO;
using Booking.Application.Errors;
using Booking.Application.Services;

namespace Booking.API.Controllers.UserControllers;

[ApiController]
[Route("user")]
public class UserAuthenticationController(UserService userService) : ControllerBase
{
  private readonly UserService _userService = userService;
  
  [HttpPost]
  [Route("login")]
  public async Task<IActionResult> Login([FromBody] UserLogin dto)
  {
    Result<string> result = await _userService.Login(dto);
    if (!result.IsSuccess) return Unauthorized(result?.Error?.ToResponse());
    Response.Cookies.Append("satisfy", result.Value ?? "");
    Response.Cookies.Append("username", dto.Username);
    return Ok();
  }

  [HttpPost]
  [Route("register")]
  public async Task<IActionResult> Register([FromBody] UserRegistration dto)
  {
    Result<bool> result = await _userService.Register(dto);
    if (!result.IsSuccess) return Unauthorized(result?.Error?.ToResponse());
    return Ok();
  }
}