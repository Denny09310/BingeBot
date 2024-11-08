using System.Text.Json.Serialization;

namespace BingeBot.Models;

public partial class EpisodeToAir
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("overview")]
    public string Overview { get; set; } = default!;

    [JsonPropertyName("vote_average")]
    public double VoteAverage { get; set; }

    [JsonPropertyName("vote_count")]
    public long VoteCount { get; set; }

    [JsonPropertyName("air_date")]
    public DateTimeOffset AirDate { get; set; }

    [JsonPropertyName("episode_number")]
    public long EpisodeNumber { get; set; }

    [JsonPropertyName("episode_type")]
    public string EpisodeType { get; set; } = default!;

    [JsonPropertyName("production_code")]
    public string ProductionCode { get; set; } = default!;

    [JsonPropertyName("runtime")]
    public long Runtime { get; set; }

    [JsonPropertyName("season_number")]
    public long SeasonNumber { get; set; }

    [JsonPropertyName("show_id")]
    public long ShowId { get; set; }

    [JsonPropertyName("still_path")]
    public string StillPath { get; set; } = default!;
}

