using ApiAuth.Models;

namespace Models
{
  public class User : BaseModel
  {
    public UserAuth Auth { get; set; }    
    public string Email { get; set; }
  }
}
