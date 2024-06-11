using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Pryaniky.Data;

public static class ServiceCollectionExtensions
{

    public static IServiceCollection AddAppDbContext(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContextFactory<PryanikyDbContext, DbContextFactory>();
        serviceCollection.AddScoped(f => f.GetRequiredService<IDbContextFactory<PryanikyDbContext>>().CreateDbContext());

        serviceCollection.AddDbContext<PryanikyDbContext>();

        return serviceCollection;
    }
}