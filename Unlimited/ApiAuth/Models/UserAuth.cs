using System.Text.Json.Serialization;

namespace ApiAuth.Models
{
  public class UserAuth
  {
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public string LastName { get; set; }
    public required string Username { get; set; }

    [JsonIgnore]
    public string Password { get; set; }
    public bool isActive { get; set; }
  }
}
