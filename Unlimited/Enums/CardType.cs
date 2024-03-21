using System.Text.Json.Serialization;

namespace Enums
{
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum CardType
  {
    Leader = 1,
    Base = 2,
    Unit = 3,
    Event = 4,
    Upgrade = 5
  }
}
