using Microsoft.Extensions.DependencyInjection;

namespace Pryaniky.Business.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddBusiness(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IOrderService, OrderService>();

        serviceCollection.AddScoped<IProductService, ProductService>();
    }
}