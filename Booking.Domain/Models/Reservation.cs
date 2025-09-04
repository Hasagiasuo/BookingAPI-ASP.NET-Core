using System.Text.Json.Serialization;

namespace Booking.Domain.Models;

public class Reservation
{
  public Guid Id { get; set; }
  public User User { get; set; }
  public Guid UserId { get; set; }
  public Room Room { get; set; }
  public Guid RoomId { get; set; }
  public DateTime Start { get; set; }
  public DateTime End { get; set; }
}