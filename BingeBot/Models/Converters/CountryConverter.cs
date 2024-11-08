using System.Text.Json;
using System.Text.Json.Serialization;

namespace BingeBot.Models.Converters;

internal class CountryConverter : JsonConverter<Country>
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(Country);

    public override Country Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (value == "JP")
        {
            return Country.Jp;
        }
        throw new InvalidOperationException("Cannot unmarshal type OriginCountry");
    }

    public override void Write(Utf8JsonWriter writer, Country value, JsonSerializerOptions options)
    {
        if (value == Country.Jp)
        {
            JsonSerializer.Serialize(writer, "JP", options);
            return;
        }
        throw new InvalidOperationException("Cannot marshal type OriginCountry");
    }

    public static readonly CountryConverter Singleton = new();
}