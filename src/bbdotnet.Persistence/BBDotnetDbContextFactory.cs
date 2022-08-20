using Microsoft.EntityFrameworkCore.Design;

#nullable disable

namespace bbdotnet.Persistence
{
    public class BBDotnetDbContextFactory : IDesignTimeDbContextFactory<BBDotnetDbContext>
    {
        public BBDotnetDbContext CreateDbContext(string[] args)
        {
            var connectionString = "Data Source=./bbdotnet.db";

            return new BBDotnetDbContext(connectionString);
        }
    }
}
