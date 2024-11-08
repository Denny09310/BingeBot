using FastEndpoints;
using BingeBot.Commands;

namespace Jobs.Get.Id;

sealed class Endpoint(ITmdbClient tmdb) : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("/jobs/add/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        // Find the language of the user
        var language = HttpContext.Request.GetTypedHeaders().AcceptLanguage
            .OrderByDescending(l => l.Quality)
            .Select(l => l.Value)
            .First();

        // Find the tv series from TMDB
        using var response = await tmdb.GetTvSeriesAsync(req.Id, language.Value);

        // If TMDB returned an error response bubble up to the api
        if (!response.IsSuccessful)
        {
            ThrowError(x => x.Id, response.ReasonPhrase ?? "Unhandled Exception", (int)response.StatusCode);
        }

        var nextEpisodeToAir = response.Content.NextEpisodeToAir;
        
        var command = new AddDownloadCommand { EpisodeId = nextEpisodeToAir.Id, NextAirDate = nextEpisodeToAir.AirDate };
        Response.TrackingId = await command.QueueJobAsync(
            executeAfter: DateTime.UtcNow + command.NextAirDate.TimeOfDay,
            ct: ct);

        await SendOkAsync(Response, ct);
    }
}