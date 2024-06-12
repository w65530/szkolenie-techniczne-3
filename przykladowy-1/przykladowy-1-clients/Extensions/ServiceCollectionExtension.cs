using przykladowy_1_client.Resolvers;
using przykladowy_1_client.Services;

namespace przykladowy_1_client.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddClientServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<ClientService>();
        serviceCollection.AddTransient<CarServiceService>();
        serviceCollection.AddTransient<CarServiceResolver>();
        serviceCollection.AddDbContext<ClientServiceDbContext>();

        return serviceCollection;
    }
}