using System.Text.Json.Serialization;

namespace BingeBot.Models;

public partial class Genre
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;
}

