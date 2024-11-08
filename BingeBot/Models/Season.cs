using System.Text.Json.Serialization;

namespace BingeBot.Models;

public partial class Season
{
    [JsonPropertyName("air_date")]
    public DateTimeOffset AirDate { get; set; }

    [JsonPropertyName("episode_count")]
    public long EpisodeCount { get; set; }

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("overview")]
    public string Overview { get; set; } = default!;

    [JsonPropertyName("poster_path")]
    public string PosterPath { get; set; } = default!;

    [JsonPropertyName("season_number")]
    public long SeasonNumber { get; set; }

    [JsonPropertyName("vote_average")]
    public double VoteAverage { get; set; }
}

