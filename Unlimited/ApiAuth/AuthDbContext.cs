using ApiAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAuth
{
  public class AuthDbContext : DbContext
  {
    private readonly DbContextOptions _options;
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
      _options = options;
    }

    public DbSet<UserAuth> UserAuthorization { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<UserAuth>().HasData(
                new UserAuth
                {
                  Id = 1,
                  FirstName = "Admin",
                  LastName = "Account",
                  Username = "sa",
                  Password = "!@#$%A1",
                }
            );
    }
  }
}
