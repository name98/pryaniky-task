using Microsoft.EntityFrameworkCore;

namespace Pryaniky.Data;

internal class DbContextFactory : IDbContextFactory<PryanikyDbContext>
{
    public PryanikyDbContext CreateDbContext()
    {
        var dbContextOptionsBuilder = new DbContextOptionsBuilder();
        dbContextOptionsBuilder.UseSqlite("Data Source=app.db");

        return new PryanikyDbContext(dbContextOptionsBuilder.Options);
    }
}