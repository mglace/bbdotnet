using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace bbdotnet.Infrastructure.Persistence;

internal class BBDotnetDbContextDesignTimeFactory : IDesignTimeDbContextFactory<BBDotnetDbContext>
{
    public BBDotnetDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<BBDotnetDbContext>();

        builder.UseSqlite("Data Source=bbdotnet.db");

        return new BBDotnetDbContext(builder.Options);
    }
}
