using FastEndpoints;

namespace BingeBot.Commands;

public sealed class AddDownloadCommand : ICommand
{
    public DateTimeOffset NextAirDate { get; set; }
    public long EpisodeId { get; set; }
}

public sealed class AddDownloadCommandHandler(ILogger<AddDownloadCommandHandler> logger) : ICommandHandler<AddDownloadCommand>
{
    public Task ExecuteAsync(AddDownloadCommand command, CancellationToken ct)
    {
        logger.LogInformation("Doing queued job!");
        return Task.CompletedTask;
    }
}
