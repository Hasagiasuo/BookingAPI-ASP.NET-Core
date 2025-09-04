namespace Booking.Domain.Models;

public class Room(string title, int capacity)
{
  public Guid Id { get; set; }
  public int Count { get; set; } = 0;
  public string Title { get; set; } = title; 
  public int Capacity { get; set; } = capacity;
  public ICollection<Reservation> Reservations { get; set; } = [];
}