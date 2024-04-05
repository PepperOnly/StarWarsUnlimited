using Enums;
using Models;
using Unlimited.Repository.Interfaces;
using Unlimited.Service.Interfaces;

namespace Unlimited.Service.Services
{
  public class CollectionService : BaseService<Collection>, ICollectionService
  {
    private readonly ICollectionRepository _collectionRepository;
    private readonly ICardService _cardService;    

    public CollectionService(ICollectionRepository collectionRepository, ICardService cardService) : base(collectionRepository)
    {
      _collectionRepository = collectionRepository;
      _cardService = cardService;
    }

    public async Task<bool> AddCardToCollection(Guid userId, Guid collectionId, string number, int cardSet, int cardMake, int quantity)
    {
      //get collection
      var result = false;
      var collection = await _collectionRepository.GetById(collectionId);
      var card = await _cardService.GetCardByNumberAndSet(number, cardSet);

      var cardToAdd = new CollectionCard()
      {
        CardId = card.Id,
        CollectionId = collectionId,
        Quantity = quantity        
      };

      //Make sure card doesnt already exist in collection
      var existInCollection = await DoesCardExistInCollection(collectionId, card.Id);

      if (!existInCollection)
      {
        //Add card to collection
        result = await _collectionRepository.AddCardToCollection(collection.Id, cardToAdd);
      }
      else
      {
        throw new Exception($"Card AlreAdy exists in collection, Number: {number}, Set: {(CardSet)cardSet}, Card: {card.Name}");
      }

      return result;
    }

    public async Task<bool> DoesCardExistInCollection(Guid collectionId, Guid cardId)
    {
      return await _collectionRepository.DoesCardExistInCollection(collectionId, cardId);
    }

    public async Task<Guid> GetCollectionIdByUserId(Guid userId)
    {
      return await _collectionRepository.GetCollectionIdByUserId(userId);
    }

    public async Task UpdateCollectionValue(Guid collectionId)
    {
      //var collection = await _collectionRepository.GetById(collectionId);

      //foreach (var card in collection.Cards)
      //{
      //  //Convert To Rand from USD
      //  double.TryParse(card.Card.MarketPrice, out double usd);

      //  card.Value = card.Card.MarketPrice;
      //}

      ////update db
      //await _collectionRepository.Update(collection);
    }
  }
}
