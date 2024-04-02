using ApiAuth.Models;

namespace Models
{
  public class User : BaseModel
  {
    public int AuthId { get; set; } // Foreign key to UserAuth in another database    
    public string Email { get; set; }
  }
}
