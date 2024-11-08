using System.Text.Json.Serialization;

namespace BingeBot.Models;

public partial class ProductionCountry
{
    [JsonPropertyName("iso_3166_1")]
    public Country Iso3166_1 { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;
}

