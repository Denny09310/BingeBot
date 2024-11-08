using System.Text.Json.Serialization;

namespace BingeBot.Models;

public partial class TvSeries
{
    [JsonPropertyName("adult")]
    public bool Adult { get; set; }

    [JsonPropertyName("backdrop_path")]
    public string BackdropPath { get; set; } = default!;

    [JsonPropertyName("created_by")]
    public object[] CreatedBy { get; set; } = default!;

    [JsonPropertyName("episode_run_time")]
    public long[] EpisodeRunTime { get; set; } = default!;

    [JsonPropertyName("first_air_date")]
    public DateTimeOffset FirstAirDate { get; set; }

    [JsonPropertyName("genres")]
    public Genre[] Genres { get; set; } = default!;

    [JsonPropertyName("homepage")]
    public Uri Homepage { get; set; } = default!;

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("in_production")]
    public bool InProduction { get; set; }

    [JsonPropertyName("languages")]
    public string[] Languages { get; set; } = default!;

    [JsonPropertyName("last_air_date")]
    public DateTimeOffset LastAirDate { get; set; }

    [JsonPropertyName("last_episode_to_air")]
    public EpisodeToAir LastEpisodeToAir { get; set; } = default!;

    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("next_episode_to_air")]
    public EpisodeToAir NextEpisodeToAir { get; set; } = default!;

    [JsonPropertyName("networks")]
    public Network[] Networks { get; set; } = default!;

    [JsonPropertyName("number_of_episodes")]
    public long NumberOfEpisodes { get; set; }

    [JsonPropertyName("number_of_seasons")]
    public long NumberOfSeasons { get; set; }

    [JsonPropertyName("origin_country")]
    public Country[] OriginCountry { get; set; } = default!;

    [JsonPropertyName("original_language")]
    public string OriginalLanguage { get; set; } = default!;

    [JsonPropertyName("original_name")]
    public string OriginalName { get; set; } = default!;

    [JsonPropertyName("overview")]
    public string Overview { get; set; } = default!;

    [JsonPropertyName("popularity")]
    public double Popularity { get; set; }

    [JsonPropertyName("poster_path")]
    public string PosterPath { get; set; } = default!;

    [JsonPropertyName("production_companies")]
    public Network[] ProductionCompanies { get; set; } = default!;

    [JsonPropertyName("production_countries")]
    public ProductionCountry[] ProductionCountries { get; set; } = default!;

    [JsonPropertyName("seasons")]
    public Season[] Seasons { get; set; } = default!;

    [JsonPropertyName("spoken_languages")]
    public SpokenLanguage[] SpokenLanguages { get; set; } = default!;

    [JsonPropertyName("status")]
    public string Status { get; set; } = default!;

    [JsonPropertyName("tagline")]
    public string Tagline { get; set; } = default!;

    [JsonPropertyName("type")]
    public string Type { get; set; } = default!;

    [JsonPropertyName("vote_average")]
    public double VoteAverage { get; set; }

    [JsonPropertyName("vote_count")]
    public long VoteCount { get; set; }
}

