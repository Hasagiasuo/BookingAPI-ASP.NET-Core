namespace Booking.Application.DTO;

public record ReservationCreate(string RoomTitle, int Count, DateTime Start, DateTime End);

public record ReservationResponce(string Username, string RoomTitle, DateTime Start, DateTime End);