using Microsoft.EntityFrameworkCore;
using Models;

namespace Unlimited.Repository
{
  public class UnlimitedDbContext : DbContext
  {
    public UnlimitedDbContext(DbContextOptions<UnlimitedDbContext> options) : base(options)
    {
    }

    public DbSet<Card> Cards { get; set; }
  }
}
