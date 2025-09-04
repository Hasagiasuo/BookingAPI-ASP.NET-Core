using Booking.Application.Interfaces.Outcomes;

namespace Booking.Application.Errors;

public class Result<T> 
{
  public T? Value { get; }
  public IError?  Error { get; }
  public bool IsSuccess => Error is null;
  private Result(T value) => Value = value;
  private Result(IError error) => Error = error;
  public static Result<T> Ok(T value) => new(value);
  public static Result<T> Fail(IError error) => new(error);
}