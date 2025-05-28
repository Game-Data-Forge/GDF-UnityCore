#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj CloudUrlTools.cs create at 2025/05/20 10:05:01
// ©2024-2025 idéMobi SARL FRANCE

#endregion

using System;
using Newtonsoft.Json;

namespace GDFFoundation
{
    public class NewtonCountryConverter : JsonConverter<Country>
    {
        public override Country ReadJson(JsonReader reader, Type objectType, Country existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Integer)
            {
                return (Country)Convert.ToInt16(reader.Value);
            }

            if (reader.TokenType != JsonToken.String)
            {
                throw new JsonException();
            }

            string value = Convert.ToString(reader.Value);

            if (short.TryParse(value, out var shortValue))
            {
                return (Country)shortValue;
            }

            return Enum.Parse<Country>(value);
        }

        public override void WriteJson(JsonWriter writer, Country value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToCodeString());
        }
    }
}