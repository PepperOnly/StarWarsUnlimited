using System.Text.Json.Serialization;

namespace Enums
{
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum CardMake
  {
    Normal = 1,
    Foil = 2    
  }
}
