﻿using System.Text.Json.Serialization;

namespace Enums
{
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum CardAspect
  {
    None = 0,
    Vigilance = 1,
    Command = 2,
    Aggression = 3,
    Cunning = 4,
    Villainy = 5,
    Heroism = 6
  }
}
