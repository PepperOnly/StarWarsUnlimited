namespace ApiAuth.Models
{
  public class AuthenticationSettings
  {
    public bool AuthenticationEnabled { get; set; }
    public string Secret { get; set; } = string.Empty;
  }
}
