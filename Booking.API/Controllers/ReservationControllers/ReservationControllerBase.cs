using Booking.Application.DTO;
using Booking.Application.Errors;
using Booking.Application.Services;
using Booking.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers.ReservationControllers;

[ApiController]
[Route("reserv")]
[Authorize(Roles = "Admin")]
public class ReservationController(ReservationService reservationService) : ControllerBase
{
  private readonly ReservationService _reservationService = reservationService;

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    ICollection<ReservationResponce> reservs = await _reservationService.GetAll();
    return Ok(reservs.ToList());
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] ReservationCreate dto)
  {
    string username = Request.Cookies["username"] ?? "";
    if (username == "") return Unauthorized("Login first");
    Result<bool> result = await _reservationService.Create(dto, username);
    if (!result.IsSuccess) return StatusCode(500, new { error = result.Error!.ToResponse() });
    return Ok();
  }
}