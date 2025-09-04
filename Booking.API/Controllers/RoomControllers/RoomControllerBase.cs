using Booking.Application.DTO;
using Booking.Application.Errors;
using Booking.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers.RoomControllers;

[ApiController]
[Route("room")]
[Authorize(Roles = "Admin")]
public class RoomController(RoomService roomService) : ControllerBase
{
  private readonly RoomService _roomService = roomService;

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] RoomCreate dto)
  {
    Result<bool> res = await _roomService.Create(dto);
    if (res.IsSuccess) return Ok();
    else return StatusCode(500, new { error = res.Error!.ToResponse() });
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    return Ok(await _roomService.GetAll());
  }
}