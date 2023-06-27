using CryptoKickStake.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace CryptoKickStake.Infrastructure.Database;

public class CryptoKickStakeDbContext : DbContext
{
    public CryptoKickStakeDbContext(DbContextOptions<CryptoKickStakeDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>()
            .HasOne(b => b.Result)
            .WithOne(p => p.Event)
            .HasForeignKey<Event>(e=>e.ResultId);
    }

    public DbSet<Event> Events { get; set; }

    public DbSet<Party> Parties { get; set; }

    public DbSet<Result> Results { get; set; }
}