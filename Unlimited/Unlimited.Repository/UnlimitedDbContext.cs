using Microsoft.EntityFrameworkCore;
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
    public DbSet<Collection> Collections { get; set; }
    public DbSet<CollectionCard> CollectionCards { get; set; }
    public DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

      //Card
      modelBuilder.Entity<Card>()
    .Property(x => x.Cost)
    .HasDefaultValue("0");

      modelBuilder.Entity<Card>()
    .Property(x => x.Power)
    .HasDefaultValue("0");

      modelBuilder.Entity<Card>()
    .Property(x => x.HP)
    .HasDefaultValue("0");

      modelBuilder.Entity<Card>()
    .Property(x => x.Subtitle)
    .HasDefaultValue("None");

      modelBuilder.Entity<Card>()
          .HasKey(e => new { e.Set, e.Number });

    }
  }
}
