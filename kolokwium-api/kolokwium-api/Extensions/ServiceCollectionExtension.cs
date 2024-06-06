using kolokwium_api.Services;

namespace kolokwium_api.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCompanyServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<CompanyService>();
        serviceCollection.AddDbContext<CompanyDbContext>();
        return serviceCollection;
    }
}