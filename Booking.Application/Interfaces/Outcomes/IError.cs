namespace Booking.Application.Interfaces.Outcomes;

public interface IError
{
  string Code { get; }  
  string Message { get; }
  string ToResponse();
}