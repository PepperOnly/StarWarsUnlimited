using System.ComponentModel;

namespace ApiAuth.Models
{
  public class AuthenticateRequest
  {
    [DefaultValue("System")]
    public required string Username { get; set; }

    [DefaultValue("System")]
    public required string Password { get; set; }
  }
}
