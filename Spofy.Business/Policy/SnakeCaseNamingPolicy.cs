﻿using System.Text.Json;

namespace Spotfy.Business.Policy
{
    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            return string.Concat(name.Select((character, index) =>
                index > 0 && char.IsUpper(character)
                    ? "_" + character.ToString()
                    : character.ToString()
            )).ToLower();
        }
    }
}
