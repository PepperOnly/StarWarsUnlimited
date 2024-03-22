using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Models;
using Moq;
using Unlimited.Repository.Repositories;

namespace Unlimited.Repository.Tests
{
  [TestFixture]
  public class CardRepositoryTests
  {
    [Test]
    public void GetAll_ReturnsAllCards()
    {
      // Arrange
      var cards = new List<Card>
            {
                new Card { Id = Guid.NewGuid(), Set = Enums.CardSet.SOR, Number = "001", Artist ="Picaso", Cost = "5", FrontArt ="www.art.co.za/123.png", HP = "7", Name = "Vader", Power = "10", Rarity = "R", Subtitle = "DarkSIde" },
                new Card { Id = Guid.NewGuid(), Set = Enums.CardSet.SOG, Number = "001", Artist ="Picaso", Cost = "5", FrontArt ="www.art.co.za/123.png", HP = "7", Name = "Vader", Power = "10", Rarity = "R", Subtitle = "DarkSIde" },
                new Card { Id = Guid.NewGuid(), Set = Enums.CardSet.TOR, Number = "002", Artist ="Picaso", Cost = "5", FrontArt ="www.art.co.za/123.png", HP = "7", Name = "Vader", Power = "10", Rarity = "R", Subtitle = "DarkSIde"}
            };

      var options = new DbContextOptionsBuilder<UnlimitedDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

      using (var context = new UnlimitedDbContext(options))
      {
        context.Cards.AddRange(cards);
        context.SaveChanges();
      }

      using (var context = new UnlimitedDbContext(options))
      {
        var repository = new CardRepository(context);

        // Act
        var result = repository.GetAll();

        // Assert
        result.Should().HaveCount(3);
      }
    }

  }
}
