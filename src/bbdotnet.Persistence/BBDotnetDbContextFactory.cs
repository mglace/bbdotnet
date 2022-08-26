using Microsoft.EntityFrameworkCore.Design;

#nullable disable

namespace bbdotnet.Persistence
{
    public class BBDotnetDbContextFactory : IDesignTimeDbContextFactory<BBDotnetDbContext>
    {
        public BBDotnetDbContext CreateDbContext(string[] args)
        {
            var connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=bbdotnet;Integrated Security=True;MultipleActiveResultSets=True";

            return new BBDotnetDbContext(connectionString);
        }
    }
}
