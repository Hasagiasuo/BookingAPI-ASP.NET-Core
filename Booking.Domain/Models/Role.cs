using System.Text.Json.Serialization;

namespace Booking.Domain.Models;

public class Role
{
  public Guid Id { get; set; }  
  public string Title { get; set; }
  [JsonIgnore]
  public ICollection<User> Users { get; set; }
}