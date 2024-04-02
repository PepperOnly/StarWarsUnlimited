﻿using System.Text.Json.Serialization;

namespace Enums
{
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum CardSet
  {
    SOR = 1,
    SOROP = 2    
  }
}
