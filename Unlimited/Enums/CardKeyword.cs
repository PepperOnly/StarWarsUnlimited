using System.Text.Json.Serialization;

namespace Enums
{
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum CardKeyword
  {
    None = 0,
    Ambush = 1,
    Grit = 2,
    Overwhelm = 3,
    Raid = 4,
    Restore = 5,
    Saboteur = 6,
    Sentinel = 7,
    Shielded = 8
  }
}
