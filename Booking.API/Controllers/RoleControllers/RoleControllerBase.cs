using Booking.Application.DTO;
using Booking.Application.Errors;
using Booking.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers.RoleControllers;

[ApiController]
[Route("role")]
[Authorize(Roles = "Admin")]
public class RoleControllerBase(RoleService service) : ControllerBase
{
  private readonly RoleService _service = service;

  [HttpPost]
  public async Task<IActionResult> CreateRole([FromBody] RoleCreate dto)
  {
    Result<bool> res = await _service.Create(dto);
    return res.IsSuccess ? Ok() : StatusCode(500, new { error = res.Error!.ToResponse() });
  }

  [HttpGet]
  public async Task<IActionResult> GetRoles()
  {
    return Ok(await _service.GetAll());
  }

  [HttpDelete("{title}")]
  public async Task<IActionResult> DeleteRoleByTitle(string title)
  {
    Result<bool> res = await _service.DeleteByTitle(title);
    return res.IsSuccess ? Ok() : StatusCode(500, new { error = res.Error!.ToResponse() }); 
  }
}