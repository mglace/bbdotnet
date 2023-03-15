using bbdotnet.Domain;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace bbdotnet.Persistence;

public class BBDotnetDbContext : DbContext
{
    public BBDotnetDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BBDotnetDbContext).Assembly);
    }

    public DbSet<Topic> Topics { get; set; }

    public DbSet<Post> Posts { get; set; }

    public DbSet<Flag> Flags { get; set; }
}
