using Microsoft.Extensions.DependencyInjection;
using SzkolenieTechniczne.JobAdvertisement.Api.Services;
using SzkolenieTechniczne.JobAdvertisement.Storage;

namespace SzkolenieTechniczne.JobAdvertisement.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAdvertisementServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<JobPositionAdvertisementService>();
            serviceCollection.AddDbContext<JobPositionAdvertisementDbContext, JobPositionAdvertisementDbContext>();
            return serviceCollection;
        }
    }
}
