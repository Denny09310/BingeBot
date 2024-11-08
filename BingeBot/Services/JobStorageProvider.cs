using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace BingeBot.Services;

public class JobStorageProvider(IDbContextFactory<ApplicationDbContext> dbFactory) : IJobStorageProvider<JobRecord>
{
    public async Task CancelJobAsync(Guid trackingId, CancellationToken ct)
    {
        using var db = await dbFactory.CreateDbContextAsync(ct);
        var job = await db.Jobs.FirstOrDefaultAsync(j => j.TrackingID == trackingId, ct);

        if (job != null)
        {
            job.IsComplete = true;
            db.Jobs.Update(job);
            await db.SaveChangesAsync(ct);
        }
    }

    public async Task<IEnumerable<JobRecord>> GetNextBatchAsync(PendingJobSearchParams<JobRecord> parameters)
    {
        using var db = await dbFactory.CreateDbContextAsync();
        return await db.Jobs.Where(parameters.Match)
            .Take(parameters.Limit)
            .ToListAsync();
    }

    public async Task MarkJobAsCompleteAsync(JobRecord r, CancellationToken ct)
    {
        using var db = await dbFactory.CreateDbContextAsync(ct);
        db.Jobs.Update(r);
        await db.SaveChangesAsync(ct);
    }

    public async Task OnHandlerExecutionFailureAsync(JobRecord r, Exception exception, CancellationToken ct)
    {
        using var db = await dbFactory.CreateDbContextAsync(ct);
        r.ExecuteAfter = DateTime.UtcNow.AddMinutes(1);
        db.Jobs.Update(r);
        await db.SaveChangesAsync(ct);
    }

    public async Task PurgeStaleJobsAsync(StaleJobSearchParams<JobRecord> parameters)
    {
        using var db = await dbFactory.CreateDbContextAsync();
        var staleJobs = await db.Jobs.Where(parameters.Match).ToListAsync();
        db.Jobs.RemoveRange(staleJobs);
        await db.SaveChangesAsync();
    }

    public async Task StoreJobAsync(JobRecord r, CancellationToken ct)
    {
        using var db = await dbFactory.CreateDbContextAsync(ct);
        await db.Jobs.AddAsync(r, ct);
        await db.SaveChangesAsync(ct);
    }
}

public class JobRecord : IJobStorageRecord, IJobResultStorage
{
    public object Command { get; set; } = default!;
    public DateTime ExecuteAfter { get; set; }
    public DateTime ExpireOn { get; set; }
    public bool IsComplete { get; set; }
    public string QueueID { get; set; } = default!;
    public object? Result { get; set; }
    public Guid TrackingID { get; set; }
}