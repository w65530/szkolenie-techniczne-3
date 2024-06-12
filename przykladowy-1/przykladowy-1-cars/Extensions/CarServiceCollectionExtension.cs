using przykladowy_1_cars.Services;

namespace przykladowy_1_cars.Extensions;

public static class CarServiceCollectionExtension
{
    public static IServiceCollection AddCarServicesServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<CarServiceDbContext>();
        serviceCollection.AddTransient<CarServiceService>();
        return serviceCollection;
    }
}