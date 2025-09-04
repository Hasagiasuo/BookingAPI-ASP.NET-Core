namespace Booking.Application.DTO;

public record UserRegistration(string Username, string Password, string RoleTitle);
public record UserLogin(string Username, string Password);
