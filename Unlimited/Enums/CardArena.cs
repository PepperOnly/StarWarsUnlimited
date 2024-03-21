using System.Text.Json.Serialization;

namespace Enums
{
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum CardArena
  {
    None = 0,
    Ground = 1,
    Space = 2
  }
}
