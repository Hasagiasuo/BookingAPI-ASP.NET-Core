using Booking.Application.Interfaces.Outcomes;

namespace Booking.Application.Errors;

public class ValidationError(string message, string field) : IError 
{
  public string Code { get; } = "VALIDATION_ERROR";
  public string Message { get; } = message;
  public string Field { get; } = field;
  public string ToResponse()
  {
    return Code + " | Error message: " + Message + " | Not validation field: " + Field;;
  }

}

public class RegistrationError(string message) : IError 
{
  public string Code { get; } = "REGISTER_ERROR";
  public string Message { get; } = message;
  public string ToResponse()
  {
    return Code + " | Error message: " + Message;
  }
}

public class DataBaseError(string message, string table) : IError
{
  public string Table { get; } = table;
  public string Code { get; } = "DATABASE_ERROR";
  public string Message { get; } = message;
  public string ToResponse()
  {
    return Code + " | Error message: " + Message + " | Table: " + Table;;
  }
}

public class MapperError(string message, string dtoName) : IError
{
  public string Code { get; } = "MAPPER_ERROR";

  public string Message { get; } = message;
  public string DtoName { get; } = dtoName;

  public string ToResponse()
  {
    return Code + " | Error message: " + Message + " | Dto name: " + DtoName;;
  }
}

public class IntervalShedulingError(string message) : IError
{
  public string Code { get; } = "INTERVAL_ERROR";

  public string Message { get; } = message;

  public string ToResponse()
  {
    return Code + " | Error message: " + Message;
  }
}