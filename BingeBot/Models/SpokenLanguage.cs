using System.Text.Json.Serialization;

namespace BingeBot.Models;

public partial class SpokenLanguage
{
    [JsonPropertyName("english_name")]
    public string EnglishName { get; set; } = default!;

    [JsonPropertyName("iso_639_1")]
    public string Iso639_1 { get; set; } = default!;

    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;
}

