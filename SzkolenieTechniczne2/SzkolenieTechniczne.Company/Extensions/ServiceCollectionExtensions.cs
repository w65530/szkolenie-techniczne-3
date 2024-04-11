using Microsoft.Extensions.DependencyInjection;
using SzkolenieTechniczne.Company.Services;
using SzkolenieTechniczne.Company.Storage;

namespace SzkolenieTechniczne.Company.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGeoServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<CompanyService>();
            serviceCollection.AddTransient<JobPositionService>();
            serviceCollection.AddDbContext<CompanyDbContext>();
            return serviceCollection;
        }
    }

}
