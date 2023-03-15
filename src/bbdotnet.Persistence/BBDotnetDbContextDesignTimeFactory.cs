using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace bbdotnet.Persistence;

internal class BBDotnetDbContextDesignTimeFactory : IDesignTimeDbContextFactory<BBDotnetDbContext>
{
    public BBDotnetDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<BBDotnetDbContext>();

        builder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=PhantasyGames;Integrated Security=SSPI");

        return new BBDotnetDbContext(builder.Options);
    }
}
