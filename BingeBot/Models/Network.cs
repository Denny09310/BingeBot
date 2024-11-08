using System.Text.Json.Serialization;

namespace BingeBot.Models;

public partial class Network
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("logo_path")]
    public string LogoPath { get; set; } = default!;

    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("origin_country")]
    public Country OriginCountry { get; set; }
}

