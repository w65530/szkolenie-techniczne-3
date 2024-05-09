using Microsoft.Extensions.DependencyInjection;
using SzkolenieTechniczne.Company.Resolvers;
using SzkolenieTechniczne.Company.Services;
using SzkolenieTechniczne.Company.Storage;

namespace SzkolenieTechniczne.Company.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCompanyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<CompanyService>();
            serviceCollection.AddTransient<JobPositionService>();
            serviceCollection.AddDbContext<CompanyDbContext, CompanyDbContext>();
            serviceCollection.AddTransient<CountryIntegrationDataResolver>(); 
            return serviceCollection;
        }
    }

}
