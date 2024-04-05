using ApiAuth.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.IdentityModel.Tokens;
using Models;

namespace Unlimited.Repository
{
  public class UnlimitedDbContext : DbContext
  {
    private readonly DbContextOptions _options;

    public UnlimitedDbContext(DbContextOptions<UnlimitedDbContext> options) : base(options)
    {
      _options = options;
    }

    public DbSet<Card> Cards { get; set; }
    public DbSet<Collection> Collections { get; set; }
    public DbSet<CollectionCard> CollectionCards { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<CurrencyData> Currency { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      var userID = Guid.NewGuid();

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

      //Foreign Keys
      modelBuilder.Entity<CollectionCard>()
          .HasOne(cc => cc.Collection)
          .WithMany(c => c.Cards)
          .HasForeignKey(cc => cc.CollectionId);

      modelBuilder.Entity<CollectionCard>()
       .HasOne(cc => cc.Card)
       .WithMany()
       .HasForeignKey(cc => cc.CardId);

      //Default Data
      modelBuilder.Entity<User>().HasData(
                 new User
                 {
                   Id = userID,
                   AuthId = 1,
                   Email = "admin@unlimited.co.za"
                 }
             );

      modelBuilder.Entity<Collection>().HasData(
                 new Collection
                 {
                   UserId = userID
                 }
             );
    }
  }
}
