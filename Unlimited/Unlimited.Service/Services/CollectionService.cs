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
        Card = card,
        CardMake = (CardMake)cardMake,
        Quantity = quantity
      };

      //Make sure card doesnt already exist in collection
      var existInCollection = await DoesCardExistInCollection(collectionId, number, cardSet);

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

    public async Task<bool> DoesCardExistInCollection(Guid CollectionId, string number, int cardSet)
    {
      return await _collectionRepository.DoesCardExistInCollection(CollectionId, number, cardSet);
    }

    public async Task<Guid> GetCollectionIdByUserId(Guid userId)
    {
      return await _collectionRepository.GetCollectionIdByUserId(userId);
    }
  }
}
