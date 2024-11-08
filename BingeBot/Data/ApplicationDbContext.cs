using MessagePack;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BingeBot.Data;

public sealed class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<JobRecord> Jobs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        MessagePackSerializer.DefaultOptions
            = MessagePack.Resolvers.TypelessContractlessStandardResolver.Options;

        var converter1 = new ValueConverter<object, byte[]>(
            v => Serialize(v),
            v => Deserialize(v));

        var converter2 = new ValueConverter<object?, byte[]>(
            v => Serialize(v),
            v => Deserialize(v));

        modelBuilder.Entity<JobRecord>(entity =>
        {
            entity.HasKey(p => p.TrackingID);

            entity.Property(e => e.Command)
                  .HasConversion(converter1)
                  .HasColumnType("BLOB");

            entity.Property(e => e.Result)
                  .HasConversion(converter2)
                  .HasColumnType("BLOB");
        });
    }

    static byte[] Serialize(object? cmd) => MessagePackSerializer.Serialize(cmd);
    static object Deserialize(byte[] cmdBytes) => MessagePackSerializer.Deserialize<object>(cmdBytes);
}
