using Booking.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers.UserControllers;

[ApiController]
[Route("user/administator")]
[Authorize(Roles = "Admin")]
public class AdministratorController(UserService userService) : ControllerBase
{
  private readonly UserService _userService = userService;
  
  [HttpGet]
  public async Task<IActionResult> GetUsers()
  {
    return Ok(await _userService.GetAll());
  }
}