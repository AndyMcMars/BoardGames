using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<mdGame> Games => Set<mdGame>();
    public DbSet<mdFaction> Factions => Set<mdFaction>();
    public DbSet<mdPlayer> Players => Set<mdPlayer>();
    public DbSet<mdLocation> Locations => Set<mdLocation>();
    public DbSet<mdMatch> Matches => Set<mdMatch>();
    public DbSet<mdResult> Results => Set<mdResult>();
    public DbSet<mdReview> Reviews => Set<mdReview>();
    public DbSet<mdTournament> Tournaments => Set<mdTournament>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}