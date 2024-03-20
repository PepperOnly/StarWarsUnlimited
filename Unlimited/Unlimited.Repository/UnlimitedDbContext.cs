using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;

namespace Unlimited.Repository
{
  public class UnlimitedDbContext : DbContext
  {
    private readonly DbContextOptions _options;

    public UnlimitedDbContext(DbContextOptions options) : base(options)
    {
      _options = options;
    }

    public DbSet<Card> Cards { get; set; }
  }
}
