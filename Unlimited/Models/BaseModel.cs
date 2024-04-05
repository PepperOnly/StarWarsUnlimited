using System.ComponentModel.DataAnnotations;

namespace Models
{
  public abstract class BaseModel
  {
    public BaseModel()
    {
      Id = Guid.NewGuid();
    }

    [Key]
    public Guid Id { get; set; }
  }
}
