using Refit;
using BingeBot.Models.Converters;

namespace BingeBot.Http;

[Headers("Content-Type: application/json")]
public interface ITmdbClient
{
    [Get("/tv/{id}")]
    Task<ApiResponse<TvSeries>> GetTvSeriesAsync(int id, string? language = null);
}

public static partial class RefitExtensions
{
    private const string BaseAddress = "https://api.themoviedb.org/3/";

    public static IHttpClientBuilder AddTmdbClient(this IServiceCollection services)
    {
        var options = new RefitSettings
        {
            ContentSerializer = new SystemTextJsonContentSerializer(Converter.Settings),
        };

        return services
            .AddRefitClient<ITmdbClient>(options)
            .ConfigureHttpClient((sp, client) =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var apikey = configuration["Authorization:Tmdb"]!;

                client.BaseAddress = new Uri(BaseAddress);
                client.DefaultRequestHeaders.Authorization = new("Bearer", apikey);
            });
    }
}